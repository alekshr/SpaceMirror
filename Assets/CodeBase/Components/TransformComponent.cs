using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace CodeBase.Components
{
    [Serializable]
    public struct TransformComponent : IComponent
    {
        public Transform Transforms;
    }
}
