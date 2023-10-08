using System;
using VContainer;

namespace CodeBase.Injection
{
    [Serializable]
    public class InjectionControls : IServiceInjection
    {
        public void Configure(IContainerBuilder builder)
        {
            builder.Register<PlayerControls>(Lifetime.Singleton);
        }
    }  
}

