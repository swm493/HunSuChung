using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class AudioRequest : MonoBehaviour
{
    public TMP_InputField inputField;
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

        StartCoroutine(SendTextAndGetAudio(text));
    }

    IEnumerator SendTextAndGetAudio(string text)
{
    WWWForm form = new WWWForm();
    form.AddField("text", text);

    using (UnityWebRequest www = UnityWebRequest.Post(ngrokUrl + "/speak", form))
    {
        // 오디오 파일로 응답받기 위해 DownloadHandlerAudioClip 지정
        www.downloadHandler = new DownloadHandlerAudioClip(ngrokUrl + "/speak", AudioType.WAV);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log("🎧 음성 재생 완료!");
        }
        else
        {
            Debug.LogError("❌ 서버 요청 실패: " + www.error);
        }
    }
}

}
