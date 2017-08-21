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

        Debug.Log("注册所有的属性");

        //给派发器添加一个监听分数变更的监听器，当分数变更事件触发时，执行OnScoreChange函数
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);

        //这里是给一个局部的事件派发器添加监听
        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown,OnClickDown);


        //通过dispatcher发起请求分数的命令
        //跟哪个Command绑定就调用那个
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }
    public override void OnRemove() {
        //移除Mediator时移除这个事件监听器
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnClickDown);

    }

    public void OnScoreChange(IEvent evt) {

        //把分数传给View层去显示
        cubeView.UpdateScore((int)evt.data);
    }

    //要加分的方法
    public void OnClickDown() {

        //全局派发更新分数事件
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }
}
