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

    string message = "���õ� ������ �� ���� �Ф�";
        _ = llmCharacter.Chat(message, HandleReply);
  }
}