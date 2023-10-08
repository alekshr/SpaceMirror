using System;
using CodeBase.Components;
using CodeBase.Services.Instantiate;
using CodeBase.Services.Network;
using Mirror;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace CodeBase.Systems
{
    public class CreatePlayerSystem : IInitializer
    {
        [Inject]
        private IObjectResolver _objectResolver;
        
        [Inject]
        private IInstantiateObject<GameObject> _instantiateObject;

        [Inject] private CustomNetworkManager _customNetworkManager;

        private Guid _id;

        public World World { get; set; }

        public void OnAwake()
        {
            _customNetworkManager.OnAddPlayer += OnServerConnectCreatePlayer;
            _customNetworkManager.OnAddClientPlayer += OnClientConnectCreatePlayer;
        }

        public void Dispose()
        {
            _customNetworkManager.OnAddPlayer -= OnServerConnectCreatePlayer;
            _customNetworkManager.OnAddClientPlayer -= OnClientConnectCreatePlayer;
        }

        private void OnClientConnectCreatePlayer()
        {
            if (_id != Guid.Empty)
            {
                var player = _instantiateObject.CreateObject(_objectResolver, "PlayerCube");
                var entity = World.CreateEntity();
                entity.SetComponent(new TransformComponent{Transforms = player.transform});
                entity.SetComponent(new PlayerComponent(Guid.NewGuid()));
                Debug.Log($"{nameof(OnClientConnectCreatePlayer)} {entity}");
            }
        }

        private void OnServerConnectCreatePlayer(NetworkConnectionToClient conn)
        {
            _id = Guid.NewGuid();
            var player = _instantiateObject.CreateObject(_objectResolver, "PlayerCube");
            var entity = World.CreateEntity();
            entity.SetComponent(new TransformComponent{Transforms = player.transform});
            entity.SetComponent(new PlayerComponent(_id));
            player.name = $"{player.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, player);
            Debug.Log($"{nameof(OnServerConnectCreatePlayer)} {entity}");
        }
    }
}

