using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown; // ����Ʈ�� Unknow �̶�� �ʱ�ȭ

    private void Awake()
    {
        Init();
    }
    
    protected virtual void Init()
    {
    }

    public abstract void Clear();
}