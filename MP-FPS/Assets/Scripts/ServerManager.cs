using Mirror;
using UnityEngine;

public class ServerManager : MonoBehaviour
{
    private const string internalServerIP = "0.0.0.0";
    private ushort serverPort = 7777;

    void Start()
    {
        bool server = false;
        string[] args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "dedicatedServer")
            {
                server = true;
            }
            if (args[i] == "-port" && (i + 1 < args.Length))
            {
                serverPort = (ushort)int.Parse(args[i + 1]);
            }
        }
        if (server)
        {
            StartServer();
        }
    }

    private void StartServer()
    {
        TelepathyTransport transport = NetworkManager.singleton.GetComponent<TelepathyTransport>();
        NetworkManager.singleton.networkAddress = internalServerIP;
        transport.port = serverPort;
        NetworkManager.singleton.StartServer();
    }
}
