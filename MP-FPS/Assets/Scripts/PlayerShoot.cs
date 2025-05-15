using UnityEngine;
using Mirror;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : NetworkBehaviour
{
    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;
    
    private PlayerWeapon currentWeapon;
    private WeaponManager weaponManager;

    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced");
            this.enabled = false;
        }
        weaponManager = GetComponent<WeaponManager>();
    }

    void Update()
    {
        currentWeapon = weaponManager.GetCurrentWeapon();

        if(currentWeapon.fireRate <= 0f)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }else
        {
            if(Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating("Shoot", 0f, 1f/currentWeapon.fireRate);
            }else if(Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }
        }
    }

    //Call on server when player shoots
    [Command]
    void CmdOnShoot ()
    {
        RpcDoShootEffect();      
    }

    //Call on all clients for shoot effect
    [ClientRpc]
    void RpcDoShootEffect()
    {
        weaponManager.GetCurrentGraphics().MuzzleFlash.Play();
    }

    //Call on Hit point and normal on the surface
    [Command]
    void CmdOnHit(Vector3 pos, Vector3 normal)
    {
        RpcDoHitEffect(pos,normal);
    }

    [ClientRpc]
    void RpcDoHitEffect(Vector3 pos, Vector3 normal)
    {
        GameObject hitEffect = (GameObject)Instantiate(weaponManager.GetCurrentGraphics().hiteffectPrefab, pos, Quaternion.LookRotation(normal)); 
        Destroy(hitEffect, 2f);  
    } 

    [Client]
    void Shoot()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        CmdOnShoot();

        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, currentWeapon.range, mask))
        {
            if (hit.collider.tag == PLAYER_TAG)
            {
                PlayerShot(hit.collider.name, currentWeapon.damage);
            }

            CmdOnHit(hit.point, hit.normal);
        }
    }

    [Command]
    void PlayerShot(string playerID, int _damage)
    {
        Debug.Log(playerID + "has been shot");

        Player player = GameManager.GetPlayer(playerID);
        player.RpcTakeDamage(_damage);
    }
}
