using Scellecs.Morpeh;
using VContainer;

namespace CodeBase.Systems
{
    public class IncludePlayerControlSystem : IInitializer
    {
        [Inject] private PlayerControls _playerControls;

        public World World { get; set; }

        public void OnAwake() =>
            _playerControls.Enable();


        public void Dispose() =>
            _playerControls.Disable();
    }
}

