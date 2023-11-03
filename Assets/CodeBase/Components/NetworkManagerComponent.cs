using System;
using CodeBase.Services.Network;
using Scellecs.Morpeh;
using UnityEngine;

namespace CodeBase.Components
{
    [Serializable]
    public struct NetworkManagerComponent : IComponent
    {
        [SerializeField]
        private CustomNetworkManager _customNetworkManager;
        public CustomNetworkManager CustomNetworkManager => _customNetworkManager;
    }


    
}
