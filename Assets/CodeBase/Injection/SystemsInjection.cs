using System;
using CodeBase.Systems;
using Scellecs.Morpeh;
using VContainer;

namespace CodeBase.Injection
{
    [Serializable]
    public class SystemsInjection : IServiceInjection
    {
        public void Configure(IContainerBuilder builder)
        {
            builder.Register<IInitializer, IncludePlayerControlSystem>(Lifetime.Scoped);
            builder.Register<ISystem, InputSystem>(Lifetime.Scoped);
        }
    }
}