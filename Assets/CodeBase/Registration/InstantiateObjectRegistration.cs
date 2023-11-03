using CodeBase.Services.Instantiate;
using ThunderboltIoc;
using UnityEngine;

namespace CodeBase.Registration
{
    public partial class InstantiateObjectRegistration : ThunderboltRegistration
    {
        protected override void Register(IThunderboltRegistrar reg)
        {
            reg.AddSingleton<IInstantiateObject, InstantiateObject>();
        }
    }
}