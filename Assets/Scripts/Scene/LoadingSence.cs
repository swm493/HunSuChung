using System.Collections.Generic;
using UnityEngine;

public class LoadingSence : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Loading;
    }

    public override void Clear()
    {
    }
}