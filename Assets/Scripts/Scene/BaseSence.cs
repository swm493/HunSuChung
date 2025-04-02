using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown; // 디폴트로 Unknow 이라고 초기화

    private void Awake()
    {
        Init();
    }
    
    protected virtual void Init()
    {
    }

    public abstract void Clear();
}