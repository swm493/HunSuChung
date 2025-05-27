using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AudioManager : MonoSingleton<AudioManager>
{
    private string _ngrokUrl;
    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();

        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }

    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "ngrok_url.txt");
        if (File.Exists(path))
        {
            _ngrokUrl = File.ReadAllText(path).Trim();
            Debug.Log("✔️ ngrok 주소 로딩됨: " + _ngrokUrl);
        }
        else
        {
            Debug.LogError("❌ ngrok_url.txt 파일이 존재하지 않음!");
        }
    }

    public void RequestAudioFromText(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            Debug.LogWarning("⚠️ 변환할 텍스트가 없습니다.");
            return;
        }

        StartCoroutine(SendTextAndGetAudio(text));
    }

    IEnumerator SendTextAndGetAudio(string text)
    {
        WWWForm form = new();
        form.AddField("text", text);

        using UnityWebRequest www = UnityWebRequest.Post(_ngrokUrl + "/speak", form);
        // 오디오 파일로 응답받기 위해 DownloadHandlerAudioClip 지정
        www.downloadHandler = new DownloadHandlerAudioClip(_ngrokUrl + "/speak", AudioType.WAV);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
            _audioSource.clip = clip;
            _audioSource.Play();
            Debug.Log("🎧 음성 재생 완료!");
        }
        else
        {
            Debug.LogError("❌ 서버 요청 실패: " + www.error);
        }
    }
}
