using System;
using CodeBase.Components;
using CodeBase.Message;
using CodeBase.Services.Instantiate;
using CodeBase.Services.Network;
using Mirror;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using ThunderboltIoc;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace CodeBase.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(fileName = nameof(CreatePlayerSystem), menuName = "ECS/Systems/" + nameof(CreatePlayerSystem))]
    public class CreatePlayerSystem : Initializer
    {
        private IInstantiateObject _instantiateObject;

        private CustomNetworkManager _customNetworkManager;

        private Guid _id;
        
        public override void OnAwake()
        {
            Debug.Log($"[CreatePlayerSystem]");
            
            _instantiateObject = ThunderboltActivator.Container.Get<IInstantiateObject>();
            
            var entity = World.Filter.With<NetworkManagerComponent>().Build().First();
            ref var component = ref entity.GetComponent<NetworkManagerComponent>();
            _customNetworkManager = component.CustomNetworkManager;
            
            _customNetworkManager.OnAddPlayer += OnServerConnectCreatePlayer;
            _customNetworkManager.OnClientConnection += ClientConnection;
        }

        public override void Dispose()
        {
            _customNetworkManager.OnAddPlayer -= OnServerConnectCreatePlayer;
            _customNetworkManager.OnClientConnection -= ClientConnection;
        }

        private void ClientConnection()
        {
            _id = Guid.NewGuid();

            CharacterMessage characterMessage =
                new CharacterMessage($"Player {_id}");

            NetworkClient.Send(characterMessage);
        }
        
        private void OnServerConnectCreatePlayer(NetworkConnectionToClient conn, CharacterMessage message)
        {
            var player = _instantiateObject.CreateObject("PlayerCube");
            var entity = World.CreateEntity();
            entity.SetComponent(new TransformComponent{Transforms = player.transform});
            entity.SetComponent(new PlayerComponent(_id));
            player.name = message.Name;
            Material material = player.GetComponent<MeshRenderer>().materials[0];
            material.color = message.Color;
            NetworkServer.AddPlayerForConnection(conn, player);
            Debug.Log($"{nameof(OnServerConnectCreatePlayer)} {entity}");
        }
    }
}

