using FishNet;
using FishNet.Transporting;
using UnityEngine;

public class ClientDebug : MonoBehaviour
{
    private void OnEnable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState += OnClientState;
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState -= OnClientState;
    }

    private void OnClientState(ClientConnectionStateArgs args)
    {
        Debug.Log("CLIENT STATE: " + args.ConnectionState);
    }
}
