using CodeBase.Registration;
using Scellecs.Morpeh.Systems;
using ThunderboltIoc;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace CodeBase.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(fileName = nameof(RegistrationServiceSystem), menuName = "ECS/Systems/" + nameof(RegistrationServiceSystem))]
    public class RegistrationServiceSystem : Initializer
    {
        public override void OnAwake()
        {
            Debug.Log($"[RegistrationServiceSystem]");
            ThunderboltActivator.Attach<PlayerControlsRegistration>();
        }
    }
}
