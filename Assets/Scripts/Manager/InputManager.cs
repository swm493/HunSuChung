public class InputManager : MonoSingleton<InputManager>
{
    private GameInputSystem _inputSystem;

    public GameInputSystem.PlayerActions PlayerActions { get; private set; }
    public GameInputSystem.UIActions UIActions { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _inputSystem = new GameInputSystem();

        PlayerActions = _inputSystem.Player;
        UIActions = _inputSystem.UI;

        _inputSystem.Enable();
    }
}