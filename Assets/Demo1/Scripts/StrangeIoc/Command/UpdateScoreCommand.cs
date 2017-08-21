using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreCommand : EventCommand {

    //把数据模型注入
    [Inject]
    public ScrollModel scrollModel { get; set; }
    [Inject]
    public IScoreService scoreServce { get; set; }

    public override void Execute()
    {
        //执行更新操作
        scrollModel.Score++;
        scoreServce.UpdateScore("http://xxxxxxx",scrollModel.Score);

        //全局事件派发更新分数请求
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange,scrollModel.Score);
    }

}
