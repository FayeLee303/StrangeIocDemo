using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//开始命令
public class StartCommand : Command {
    [Inject]
    public AudioManager audioManager { get; set; }

    //当这个命令被执行的时候，默认调用Execute方法
    public override void Execute()
    {
        Debug.Log("start command execute");
        //Manager Init
        audioManager.Init();
        PoolManager.Instance.Init();//这个不需要注入
    }
}
