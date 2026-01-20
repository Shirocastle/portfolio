using UnityEngine;
using FishNet;
using FishNet.Transporting;
using FishNet.Managing;

public class NetworkBootstrap : MonoBehaviour
{
    [Header("Auto Start")]
    public bool startServer;
    public bool startClient;
    public bool startHost;

    [Header("Connection")]
    public string address = "127.0.0.1";
    public ushort port = 7779;

    void Start()
    {
        var networkManager = InstanceFinder.NetworkManager;
        var transport = networkManager.TransportManager.Transport;

        transport.SetPort(port);
        transport.SetClientAddress(address);

        if (startHost)
        {
            Debug.Log("Starting HOST");
            networkManager.ServerManager.StartConnection();
            networkManager.ClientManager.StartConnection();
            return;
        }

        if (startServer)
        {
            Debug.Log("Starting SERVER");
            networkManager.ServerManager.StartConnection();
            return;
        }

        if (startClient)
        {
            Debug.Log("Starting CLIENT");
            networkManager.ClientManager.StartConnection();
            return;
        }

        Debug.LogWarning("NetworkBootstrap: nenhum modo selecionado!");
    }
}
