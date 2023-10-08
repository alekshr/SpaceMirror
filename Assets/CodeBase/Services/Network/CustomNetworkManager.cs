using System;
using Mirror;
using UnityEngine;

namespace CodeBase.Services.Network
{
    public class CustomNetworkManager : NetworkManager
    {

        public event Action OnAddClientPlayer = delegate {  };

        
        public event Action<NetworkConnectionToClient> OnAddPlayer = delegate {  };
        
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            Debug.Log($"[CustomNetworkManager] {nameof(OnServerAddPlayer)}");
            OnAddPlayer(conn);
        }

        public override void OnClientConnect()
        {
            if (!clientLoadedScene)
            {
                // Ready/AddPlayer is usually triggered by a scene load completing.
                // if no scene was loaded, then Ready/AddPlayer it here instead.
                if (!NetworkClient.ready)
                    NetworkClient.Ready();

                if (autoCreatePlayer)
                {
                    OnAddClientPlayer();
                    NetworkClient.AddPlayer();
                }
            }
        }
    }
}

