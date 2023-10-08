using System;
using CodeBase.Services.Instantiate;
using UnityEngine;
using VContainer;

namespace CodeBase.Injection
{
    [Serializable]
    public class CreateObjectServiceInject : IServiceInjection
    {
        public void Configure(IContainerBuilder builder)
        {
            builder.Register<IInstantiateObject<GameObject> , InstantiateObject>(Lifetime.Singleton);
        }
    }
}