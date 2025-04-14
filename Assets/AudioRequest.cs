using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AudioRequest : MonoBehaviour
{
    string ngrokUrl;

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
        StartCoroutine(GetAudioClip());
    }

    IEnumerator GetAudioClip()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(ngrokUrl + "/get-audio", AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                GetComponent<AudioSource>().clip = clip;
                if (GetComponent<AudioSource>().isPlaying)
                {
                    Debug.Log("이미 재생 중입니다.");
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                Debug.LogError("요청 실패: " + www.error);
            }
        }
    }
}
