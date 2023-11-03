using CodeBase.Services.Network;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace CodeBase.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(fileName = nameof(CreateNetworkManagerSystem), menuName = "ECS/Systems/" + nameof(CreateNetworkManagerSystem))]
    public class CreateNetworkManagerSystem : Initializer
    {
        [SerializeField] private CustomNetworkManager _networkManager;
        public override void OnAwake()
        {
            Instantiate(_networkManager);
        }
    }
}
