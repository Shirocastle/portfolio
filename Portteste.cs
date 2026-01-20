using FishNet.Managing;
using UnityEngine;

public class Portteste : MonoBehaviour
{   NetworkManager networkManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       networkManager= GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(networkManager.TransportManager.Transport.GetPort());
    }
}
