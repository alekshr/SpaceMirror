using CodeBase.Components;
using CodeBase.Input;
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
    [CreateAssetMenu(fileName = nameof(InputSystem), menuName = "ECS/Systems/" + nameof(InputSystem))]
    public class InputSystem : UpdateSystem
    {
        private const float SPEED = 10.0f;
        private Vector3 _vectorInput;
        private PlayerControls _playerControls;
        private Filter _filter;
        
        public override void OnAwake()
        {
            Debug.Log($"[InputSystem]");

            _playerControls = ThunderboltActivator.Container.Get<IInputControl>().PlayerControls;
            _playerControls.Enable();
            _filter = World.Filter
                .With<TransformComponent>()
                .With<PlayerComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            _vectorInput.x = _playerControls.Move.Moveable.ReadValue<Vector2>().x;
            _vectorInput.z = _playerControls.Move.Moveable.ReadValue<Vector2>().y;
            foreach (var entity in _filter)
            {
                ref TransformComponent transformComponent = ref entity.GetComponent<TransformComponent>();
                ref PlayerComponent player = ref entity.GetComponent<PlayerComponent>();
                if (transformComponent.Transforms != null && player.PlayerNetworkProvider.isLocalPlayer)
                {
                    transformComponent.Transforms.Translate(_vectorInput * deltaTime * SPEED);
                }
            }
        }

        public override void Dispose()
        {
            _playerControls.Disable();
        }
    }
}

