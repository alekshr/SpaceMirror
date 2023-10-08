using System;
using CodeBase.Systems;
using Scellecs.Morpeh;
using VContainer;

namespace CodeBase.Injection
{
    [Serializable]
    public class InitializerSystemsInjection : IServiceInjection
    {
        public void Configure(IContainerBuilder builder)
        {
            builder.Register<IInitializer, CreatePlayerSystem>(Lifetime.Singleton);
            builder.Register<IInitializer, IncludePlayerControlSystem>(Lifetime.Singleton);
        }
    }
}

