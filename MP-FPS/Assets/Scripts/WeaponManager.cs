using UnityEngine;
using Mirror;

public class WeaponManager : NetworkBehaviour
{
    [SerializeField]
    private string weaponLayername = "Weapon";
    [SerializeField]
    private Transform weaponHolder;
    [SerializeField]
    private PlayerWeapon primaryweapon;

    private PlayerWeapon currentWeapon;
    private WeaponGraphics currentGraphics;

    void Start()
    {
        EquipWeapon(primaryweapon);
    }

    public PlayerWeapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public WeaponGraphics GetCurrentGraphics()
    {
        return currentGraphics;
    }

    void EquipWeapon (PlayerWeapon weapon)
    {
        currentWeapon = weapon;

        GameObject weaponIns = (GameObject)Instantiate(weapon.graphics, weaponHolder.position, weaponHolder.rotation);
        weaponIns.transform.SetParent(weaponHolder);

        currentGraphics = weaponIns.GetComponent<WeaponGraphics>();
        if(currentGraphics == null)
        {
            Debug.LogError("No weapon gfx on current weapon: " + weaponIns.name);
        }

        if(isLocalPlayer)
           Util.SetLayerRecursively(weaponIns, LayerMask.NameToLayer(weaponLayername));
    }
}
