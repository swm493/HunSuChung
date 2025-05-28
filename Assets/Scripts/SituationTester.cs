using UnityEngine;
using UnityEngine.UI;
using LLMUnity;
using Define;

namespace LLMUnitySamples
{
    public class SituationTester : MonoBehaviour
    {
        public LLMCharacter llmCharacter1;
        public LLMCharacter llmCharacter2;

        private string _response = "";
        public Text AIText;

        public void SubmitSituation(string situation)
        {
            if (AIText) AIText.text = "...";
            switch (GameManager.Instance.LLMCharacter)
            {
                case Character.Assister:
                    _ = llmCharacter1.Chat(
                            situation,
                            text =>
                            {
                                if (AIText) AIText.text = text;
                                _response = text;
                            },
                            () => OnModelReplyComplete());
                    break;
                case Character.Hunter:
                    _ = llmCharacter2.Chat(
                            situation,
                            text =>
                            {
                                if (AIText) AIText.text = text;
                                _response = text;
                            },
                            () => OnModelReplyComplete());
                    break;
            }
        }

        void OnModelReplyComplete()
        {
            AudioManager.Instance.RequestAudioFromText(_response);
        }

        /* 인풋 필드 직접 입력 */
        void OnInputFieldSubmit(string message)
        {
            SubmitSituation(message);
        }
    }
}