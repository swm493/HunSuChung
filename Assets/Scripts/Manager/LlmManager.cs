using LLMUnity;

public class LlmManager : MonoSingleton<InputManager>
{
    private GameInputSystem _inputSystem;

    public GameInputSystem.PlayerActions PlayerActions { get; private set; }
    public GameInputSystem.UIActions UIActions { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.llm = gameObject.GetComponent<LLM>();
    }
}