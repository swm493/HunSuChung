using Define;
using LLMUnity;

public class GameManager : MonoSingleton<GameManager>
{
    public LLM llm = null;
    public Character LLMCharacter = Character.Assister;
    public bool StartGame = false;

    protected override void Awake()
    {
        base.Awake();
        llm = GetComponent<LLM>();
    }
}