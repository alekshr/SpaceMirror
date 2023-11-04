using CodeBase.Components;
using Mirror;
using Scellecs.Morpeh;

namespace CodeBase.Providers
{
    public class PlayerNetworkProvider : NetworkBehaviour
    {
        private Entity entity;
        private void Awake()
        {
            entity = World.Default.CreateEntity();
            entity.SetComponent(new PlayerComponent(this));
            entity.SetComponent(new TransformComponent(){Transforms = gameObject.transform});
            World.Default.GetStash<PlayerComponent>().Add(entity);
        }

        private void OnDestroy()
        {
            World.Default.RemoveEntity(entity);
        }
    }
}
