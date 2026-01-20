using FishNet.Managing;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
using FishNet.Transporting;
using System;

public class SpawnDebugger : MonoBehaviour
{
    private NetworkManager _nm;

    void Awake()
    {
        _nm = GetComponent<NetworkManager>();
    }

    void Start()
    {
        // Eventos do servidor
        if (_nm.ServerManager != null)
        {
            _nm.ServerManager.OnServerConnectionState += OnServerConnectionState;
            _nm.ServerManager.OnRemoteConnectionState += OnRemoteConnectionState;
        }

        // Eventos do cliente
        if (_nm.ClientManager != null)
        {
            _nm.ClientManager.OnClientConnectionState += OnClientConnectionState;
        }

        // Eventos de objetos spawnados
        if (_nm.ClientManager != null)
        {
            _nm.ClientManager.RegisterBroadcast<SpawnMessage>(OnSpawnMessage);
        }
    }

    private void OnSpawnMessage(SpawnMessage message, Channel channel)
    {
        Debug.Log("Eiii");
    }

    void OnServerConnectionState(FishNet.Transporting.ServerConnectionStateArgs args)
    {
        Debug.Log($"🖥️ [SERVIDOR] Estado: {args.ConnectionState}");
    }

    void OnRemoteConnectionState(NetworkConnection conn, FishNet.Transporting.RemoteConnectionStateArgs args)
    {
        Debug.Log($"🖥️ [SERVIDOR] Cliente ID {conn.ClientId}: {args.ConnectionState}");
        
        if (args.ConnectionState == FishNet.Transporting.RemoteConnectionState.Started)
        {
            Debug.Log($"✅ [SERVIDOR] Cliente {conn.ClientId} conectado! PlayerSpawner deve spawnar agora...");
        }
    }

    void OnClientConnectionState(FishNet.Transporting.ClientConnectionStateArgs args)
    {
        Debug.Log($"🎮 [CLIENTE] Estado: {args.ConnectionState}");
        
        if (args.ConnectionState == FishNet.Transporting.LocalConnectionState.Started)
        {
            Debug.Log("✅ [CLIENTE] Conectado! Aguardando spawn do player...");
        }
    }

    void OnSpawnMessage(SpawnMessage msg)
    {
        Debug.Log($"📦 [CLIENTE] Objeto spawnado recebido!");
    }

    void OnDestroy()
    {
        if (_nm?.ServerManager != null)
        {
            _nm.ServerManager.OnServerConnectionState -= OnServerConnectionState;
            _nm.ServerManager.OnRemoteConnectionState -= OnRemoteConnectionState;
        }
        
        if (_nm?.ClientManager != null)
        {
            _nm.ClientManager.OnClientConnectionState -= OnClientConnectionState;
        }
    }
}

public struct SpawnMessage : FishNet.Broadcast.IBroadcast { }