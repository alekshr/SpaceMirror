using System;
using CodeBase.Components;
using Mirror;
using Scellecs.Morpeh;
using UnityEngine;

namespace CodeBase.Provider
{
    public class PlayerNetworkProvider : NetworkBehaviour
    {
        private Entity entity;
        private void Awake()
        {
            entity = World.Default.CreateEntity();
            entity.SetComponent(new TransformComponent(){Transforms = gameObject.transform});
            entity.SetComponent(new NetworkPlayerComponent(this));
        }

        private void OnDestroy()
        {
            World.Default.RemoveEntity(entity);
        }
    }
}
