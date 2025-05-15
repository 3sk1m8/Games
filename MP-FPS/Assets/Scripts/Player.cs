using UnityEngine;
using Mirror;
using UnityEngine.Assertions.Must;
using System.Collections;

[RequireComponent(typeof(PlayerSetup))]
public class Player : NetworkBehaviour
{
    [SyncVar]
    private bool isDead = false;
    public bool _isDead
    {
        get{ return isDead; }
        protected set { isDead = value; }
    }

    [SerializeField]
    private int maxHealth = 100;
    [SyncVar]
    private int currentHealth;
    [SerializeField]
    private Behaviour[] disableOnDeath;
    private bool[] wasEnabled;

    [SerializeField]
    private GameObject[] disableGameObjectsOnDeath;

    [SerializeField]
    private GameObject deathEffect;

    [SerializeField]
    private GameObject spawnEffect;

    private bool firstSetup = true;

    public void Setup()
    {
        if (isLocalPlayer)
        {
            //Switch camera
            GameManager.instance.SetSceneCameraActive(false);
            GetComponent<PlayerSetup>().playerUIinstance.SetActive(true);
        }

        CmdBroadcastSetup();
    }

    [Command]
    private void CmdBroadcastSetup()
    {
        RpcSetupPlayerOnAllClients();
    }

    [ClientRpc]
    private void RpcSetupPlayerOnAllClients()
    {
        if (firstSetup)
        {
            wasEnabled = new bool[disableOnDeath.Length];
            for (int i = 0; i < wasEnabled.Length; i++)
            {
                wasEnabled[i] = disableOnDeath[i].enabled;
            }

            firstSetup = false;
        }
        
        
        SetDefaults();
    }

    // void Update()
    // {
    //     if (!isLocalPlayer)
    //         return;

    //     if (Input.GetKeyDown(KeyCode.K))
    //     {
    //         RpcTakeDamage(999);
    //     }
    // }

    [ClientRpc]
    public void RpcTakeDamage(int amount)
    {
        if (_isDead)
            return;

        currentHealth -= amount;

        Debug.Log(transform.name + " now has " + currentHealth + " health.");

        if ( currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;

        //Disable components
        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
        }

        //Disable GameObjects
        for (int i = 0; i < disableGameObjectsOnDeath.Length; i++)
        {
            disableGameObjectsOnDeath[i].SetActive(false);
        }
        

        //Disable collider
        Collider col = GetComponent<Collider>();
        if(col != null)
           col.enabled = false;
        
        //Spawn a death effect
        GameObject gfxIns = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gfxIns, 3f);

        //Switch Camera
        if(isLocalPlayer)
        {
            GameManager.instance.SetSceneCameraActive(true);
            GetComponent<PlayerSetup>().playerUIinstance.SetActive(false);
        }

        Debug.Log(transform.name + " is DEAD!");
        
        StartCoroutine(Respawn());
    }
    
    private IEnumerator Respawn ()
    {
        yield return new WaitForSeconds(GameManager.instance.matchsettings.RespawnTime);

        Transform spawnPoint = NetworkManager.singleton.GetStartPosition();
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        yield return new WaitForSeconds(0.1f);

        Setup();
    }
    public void SetDefaults()
    {
        _isDead = false;
        currentHealth = maxHealth;

        //Set Components Active
        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = wasEnabled[i];
        }

        //Enable GameObjects
        for (int i = 0; i < disableGameObjectsOnDeath.Length; i++)
        {
            disableGameObjectsOnDeath[i].SetActive(true);
        }

        //Enable collider
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = true;
        }

        //Create spawn effect
        GameObject gfxIns = (GameObject)Instantiate(spawnEffect, transform.position, Quaternion.identity);
        gfxIns.transform.parent = null;
        gfxIns.transform.position += new Vector3(0, -1, 0);
        Destroy(gfxIns, 3f);
    }
}
