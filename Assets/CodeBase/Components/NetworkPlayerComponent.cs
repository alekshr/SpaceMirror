using Mirror;
using Scellecs.Morpeh;

namespace CodeBase.Components
{
    public struct NetworkPlayerComponent : IComponent
    {
        public NetworkBehaviour NetworkBehaviour { get; }

        public NetworkPlayerComponent(NetworkBehaviour networkBehaviour)
        {
            NetworkBehaviour = networkBehaviour;
        }
    }
}
