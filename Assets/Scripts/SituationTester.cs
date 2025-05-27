using UnityEngine;
using UnityEngine.UI;
using LLMUnity;

namespace LLMUnitySamples
{
    public class SituationTester : MonoBehaviour
    {
        public LLMCharacter llmCharacter1;
        public LLMCharacter llmCharacter2;
        public AudioRequest audioRequest;

        [Header("UI")]
        public InputField playerText;
        public Text AIText1;
        public Text AIText2;
        public Button[] situationButtons;   // 1~8번 버튼을 Inspector에 순서대로 넣어주세요

        private string response1 = "";
        private string response2 = "";

        int pendingResponses = 0;

        // 상황 문자열 배열 (버튼 인덱스와 1:1 대응)
        readonly string[] situations =
        {
            "맵을 시작한다.",
            "맵의 절반에 도달한다.",
            "맵을 클리어한다.",
            "가시에 찔린다.",
            "경사에 미끄러져서 뒤로 돌아간다.",
            "스프링에 튕겨서 뒤로 돌아간다.",
            "맵의 처음으로 돌아온다.",
            "오랜 시간동안 나아가지 못한다."
        };

        void Awake()
        {
            // 버튼이 부족/과잉으로 연결되면 경고
            if (situationButtons.Length != situations.Length)
                Debug.LogWarning("situationButtons 배열 길이가 situations 배열 길이와 다릅니다!");

            // 각 버튼에 클릭 리스너 할당
            for (int i = 0; i < situationButtons.Length; i++)
            {
                int idx = i; // 클로저 캡처 주의
                situationButtons[i].onClick.AddListener(() => SubmitSituation(situations[idx]));
            }
        }

        void Start()
        {
            playerText.onSubmit.AddListener(onInputFieldSubmit);
            playerText.Select();
        }

        /* 버튼·인풋 공통 처리 */
        void SubmitSituation(string situation)
        {
            playerText.interactable = false;
            playerText.text = situation;        // (선택) 입력창에 표시
            AIText1.text = "...";
            AIText2.text = "...";
            pendingResponses = 2;             // ★ 두 모델 대기

            _ = llmCharacter1.Chat(
                    situation,
                    text => { 
                        if (AIText1) AIText1.text = text;
                        response1 = text;
                    },
                    () => OnModelReplyComplete());

            _ = llmCharacter2.Chat(
                    situation,
                    text => { 
                        if (AIText2) AIText2.text = text;
                        response2 = text;
                    },
                    () => OnModelReplyComplete());
        }
        void OnModelReplyComplete()
        {
            pendingResponses--;
            if (pendingResponses <= 0)
            {
                AIReplyComplete();

                string fullText = response1;
                Debug.Log(fullText);

                if (audioRequest)
                    audioRequest.RequestAudioFromText(fullText);
            }
                
        }

        /* 인풋 필드 직접 입력 */
        void onInputFieldSubmit(string message)
        {
            SubmitSituation(message);
        }

        /* ========== 콜백 & 유틸 ========== */
        public void SetAIText(string text)
        {
            if (AIText1) AIText1.text = text;
            if (AIText2) AIText2.text = text;
        }

        public void AIReplyComplete()
        {
            playerText.interactable = true;
            playerText.Select();
            playerText.text = "";
        }

        public void CancelRequests()
        {
            llmCharacter1.CancelRequests();
            llmCharacter2.CancelRequests();
            AIReplyComplete();
        }

        void OnDestroy()
        {
            if (llmCharacter1) llmCharacter1.CancelRequests();
            if (llmCharacter2) llmCharacter2.CancelRequests();
        }
    }
}
