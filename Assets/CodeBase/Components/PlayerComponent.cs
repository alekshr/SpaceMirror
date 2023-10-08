using System;
using Scellecs.Morpeh;

namespace CodeBase.Components
{
    public struct PlayerComponent : IComponent
    {
        public Guid Id { get; private set; }

        public PlayerComponent(Guid id) =>
            Id = id;
    }
}