using LLMUnity;

public class GameManager : MonoSingleton<GameManager>
{
    public LLM llm = null;

    protected override void Awake()
    {
        base.Awake();
        llm = GetComponent<LLM>();
    }
}