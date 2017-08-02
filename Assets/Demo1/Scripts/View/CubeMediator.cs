using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;

public class CubeMediator : Mediator {

    //inject实现自动注入
    [Inject]
    public CubeView cubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]//定义一个事件派发器,设置他为全局派发器
    public IEventDispatcher dispatcher { get; set; }

    //当所有的属性注入之后运行时就会注册
    public override void OnRegister() {
        cubeView.Init();

        //通过dispatcher发起请求分数的命令
        //跟哪个Command绑定就调用那个
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }
    public override void OnRemove() {
    }
}
