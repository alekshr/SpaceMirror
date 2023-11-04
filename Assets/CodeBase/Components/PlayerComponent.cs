using CodeBase.Providers;
using Scellecs.Morpeh;

namespace CodeBase.Components
{
    public struct PlayerComponent : IComponent
    {
        public PlayerNetworkProvider PlayerNetworkProvider { get; }

        public PlayerComponent(PlayerNetworkProvider playerNetworkProvider)
        {
            PlayerNetworkProvider = playerNetworkProvider;
        }
    }
}