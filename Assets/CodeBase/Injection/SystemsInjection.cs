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
            builder.Register<ISystem, InputSystem>(Lifetime.Singleton);
        }
    }
}