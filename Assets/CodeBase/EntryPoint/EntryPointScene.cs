using CodeBase.Injection;
using CodeBase.Loop;
using CodeBase.Services.Network;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GodeBase.EntryPoint
{
    public class EntryPointScene : LifetimeScope
    {
        [SerializeField] private CustomNetworkManager _customNetworkManager;
        [SerializeReference, SubclassSelector] private IServiceInjection[] _serviceInjections;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_customNetworkManager);
            ConfigureInjection(builder);
            builder.RegisterEntryPoint<SceneLoop>();
        }

        private void ConfigureInjection(IContainerBuilder builder)
        {
            for (int index = 0; index < _serviceInjections.Length; index++)
            {
                _serviceInjections[index].Configure(builder);
            }
        }
    }
}

