using UnityEngine;
using Mirror;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerController))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;
    [SerializeField]
    string remoteLayerName = "RemotePlayer";
    [SerializeField]
    string dontDrawLayer = "DontDraw";
    [SerializeField]
    GameObject PlayerGraphics;
    [SerializeField]
    GameObject playerUIPrefab;
    [HideInInspector]
    public GameObject playerUIinstance;

    void Start()
    {
        if(!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteplayer();
        }else
        {
            
            //Disable player graphics for local player
            SetLayerRecursively(PlayerGraphics, LayerMask.NameToLayer(dontDrawLayer));

            //Create player ui
            playerUIinstance = Instantiate(playerUIPrefab);
            playerUIinstance.name = playerUIPrefab.name;

            //Configure player ui
            PlayerUI ui = playerUIinstance.GetComponent<PlayerUI>();
            if (ui == null)
                Debug.LogError("No playerUi component on PlayerUI Prefab");
            ui.SetController(GetComponent<PlayerController>());

            GetComponent<Player>().Setup();
        }
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();

        GameManager.RegisterPlayer(netID, player);
    }
    void AssignRemoteplayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);

    }

    void DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++ )
            {
                componentsToDisable[i].enabled = false;
            }
    }

    void OnDisable()
    {
        Destroy(playerUIinstance);

        if(isLocalPlayer)
           GameManager.instance.SetSceneCameraActive(true);

        GameManager.UnRegisterPlayer(transform.name);
    }
} 
