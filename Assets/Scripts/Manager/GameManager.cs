using Define;
using LLMUnity;

public class GameManager : MonoSingleton<GameManager>
{
    public LLM llm = null;
    public Character LLMCharacter = Character.Assister;

    protected override void Awake()
    {
        base.Awake();
        llm = GetComponent<LLM>();
    }
}