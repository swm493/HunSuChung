using LLMUnity;
using UnityEngine;

public class LLMTest : MonoBehaviour
{
    public LLMCharacter llmCharacter;

    public void HandleReply(string reply)
    {
        // do something with the reply from the model
        Debug.Log(reply);
    }

    public void Game()
    {

    string message = "¿À´Ãµµ ¼ö¾÷À» ¸ø °¬¾î ¤Ð¤Ì";
        _ = llmCharacter.Chat(message, HandleReply);
  }
}