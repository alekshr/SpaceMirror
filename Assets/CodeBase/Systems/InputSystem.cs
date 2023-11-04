using CodeBase.Components;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace CodeBase.Systems
{
    public class InputSystem : ISystem
    {
        private const float SPEED = 10.0f;
        private Vector3 _vectorInput;
        
        [Inject]
        private PlayerControls _playerControls;
        
        private Filter _filter;

        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter
                .With<TransformComponent>()
                .With<NetworkPlayerComponent>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            _vectorInput.x = _playerControls.Move.Moveable.ReadValue<Vector2>().x;
            _vectorInput.z = _playerControls.Move.Moveable.ReadValue<Vector2>().y;
            foreach (var entity in _filter)
            {
                ref TransformComponent transformComponent = ref entity.GetComponent<TransformComponent>();
                ref NetworkPlayerComponent networkPlayer = ref entity.GetComponent<NetworkPlayerComponent>();
                if (transformComponent.Transforms != null && networkPlayer.NetworkBehaviour.isLocalPlayer)
                {
                    transformComponent.Transforms.Translate(_vectorInput * deltaTime * SPEED);
                }
            }
        }

        public void Dispose()
        {
        }
    }
}

