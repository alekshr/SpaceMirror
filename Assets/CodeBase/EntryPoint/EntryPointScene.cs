using CodeBase.Injection;
using CodeBase.Loop;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.EntryPoint
{
    public class EntryPointScene : LifetimeScope
    {
        [SerializeReference] private IServiceInjection[] _serviceInjections;
        protected override void Configure(IContainerBuilder builder)
        {
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

