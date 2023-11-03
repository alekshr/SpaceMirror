using System;
using CodeBase.Message;
using Mirror;

namespace CodeBase.Services.Network
{
    public class CustomNetworkManager : NetworkManager
    {
        public event Action OnClientConnection = delegate {  };
        public event Action<NetworkConnectionToClient, CharacterMessage> OnAddPlayer = delegate {  };
        
        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<CharacterMessage>(OnCreateCharacter);
        }

        public override void OnClientConnect()
        {
            base.OnClientConnect();
            OnClientConnection();
        }
        
        private void OnCreateCharacter(NetworkConnection conn, CharacterMessage message) => 
            OnAddPlayer((NetworkConnectionToClient)conn, message);

    }
}

