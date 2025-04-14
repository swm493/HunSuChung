using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class AudioRequest : MonoBehaviour
{
    public TMP_InputField inputField;  // 🎤 텍스트 입력창 연결 필요
    private string ngrokUrl;

    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "ngrok_url.txt");

        if (File.Exists(path))
        {
            ngrokUrl = File.ReadAllText(path).Trim();
            Debug.Log("✔️ ngrok 주소 로딩됨: " + ngrokUrl);
        }
        else
        {
            Debug.LogError("❌ ngrok_url.txt 파일이 존재하지 않음!");
        }
    }

    public void RequestAudio()
    {
        string text = inputField.text;
        if (string.IsNullOrEmpty(text))
        {
            Debug.LogWarning("⚠️ 입력된 텍스트가 없습니다.");
            return;
        }

        StartCoroutine(SendTextThenGetAudio(text));
    }

    IEnumerator SendTextThenGetAudio(string text)
    {
        // 1️⃣ 텍스트를 Flask로 전송
        WWWForm form = new WWWForm();
        form.AddField("text", text);

        using (UnityWebRequest sendTextRequest = UnityWebRequest.Post(ngrokUrl + "/speak", form))
        {
            yield return sendTextRequest.SendWebRequest();

            if (sendTextRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("❌ TTS 전송 실패: " + sendTextRequest.error);
                yield break;
            }
        }

        Debug.Log("✅ 텍스트 전송 성공, 오디오 요청 중...");

        // 2️⃣ 오디오 파일 요청
        using (UnityWebRequest getAudioRequest = UnityWebRequestMultimedia.GetAudioClip(ngrokUrl + "/get-audio", AudioType.WAV))
        {
            yield return getAudioRequest.SendWebRequest();

            if (getAudioRequest.result == UnityWebRequest.Result.Success)
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(getAudioRequest);
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = clip;
                audioSource.Play();
                Debug.Log("🎧 음성 재생 시작");
            }
            else
            {
                Debug.LogError("❌ 오디오 요청 실패: " + getAudioRequest.error);
            }
        }
    }
}
