using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class AudioManager : MonoSingleton<AudioManager>
{
    private string ngrokUrl;
    private AudioSource audioSource;

    protected override void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(LoadNgrokUrl());
    }

    IEnumerator LoadNgrokUrl()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "ngrok_url.txt");

#if UNITY_ANDROID && !UNITY_EDITOR
        UnityWebRequest www = UnityWebRequest.Get(path);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            ngrokUrl = www.downloadHandler.text.Trim();
            Debug.Log("✔️ ngrok 주소 로딩됨: " + ngrokUrl);
        }
        else
        {
            Debug.LogError("❌ ngrok_url.txt 로드 실패: " + www.error);
        }
#else
        if (File.Exists(path))
        {
            ngrokUrl = File.ReadAllText(path).Trim();
            Debug.Log("✔️ ngrok 주소 로딩됨: " + ngrokUrl);
        }
        else
        {
            Debug.LogError("❌ ngrok_url.txt 파일이 존재하지 않음!");
        }
        yield return null;
#endif
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
        string postUrl = ngrokUrl + "/speak";

        // 1단계: 텍스트 전송 (POST) → 오디오 생성
        WWWForm form = new();
        form.AddField("text", text);

        using (UnityWebRequest postRequest = UnityWebRequest.Post(postUrl, form))
        {
            yield return postRequest.SendWebRequest();
            if (postRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("❌ 텍스트 전송 실패: " + postRequest.error);
                yield break;
            }
        }

        // 2단계: 생성된 오디오 다운로드
        using (UnityWebRequest getAudio = UnityWebRequestMultimedia.GetAudioClip(postUrl, AudioType.WAV))
        {
            yield return getAudio.SendWebRequest();
            if (getAudio.result == UnityWebRequest.Result.Success)
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(getAudio);
                audioSource.clip = clip;
                audioSource.Play();
                Debug.Log("🎧 음성 재생 완료!");
            }
            else
            {
                Debug.LogError("❌ 오디오 다운로드 실패: " + getAudio.error);
            }
        }
    }
}