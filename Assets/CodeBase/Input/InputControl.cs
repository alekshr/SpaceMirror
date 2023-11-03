namespace CodeBase.Input
{
    public class InputControl : IInputControl
    {
        public PlayerControls PlayerControls { get; }

        public InputControl()
        {
            PlayerControls = new PlayerControls();
        }
    }
}