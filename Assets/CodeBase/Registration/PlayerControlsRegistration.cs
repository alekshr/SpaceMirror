using CodeBase.Input;
using ThunderboltIoc;

namespace CodeBase.Registration
{
    public partial class PlayerControlsRegistration : ThunderboltRegistration
    {
        protected override void Register(IThunderboltRegistrar reg)
        {
            // reg.AddSingleton<IInputControl, InputControl>();
            reg.AddSingletonFactory<IInputControl>(() => new InputControl());

        }
    }
}

