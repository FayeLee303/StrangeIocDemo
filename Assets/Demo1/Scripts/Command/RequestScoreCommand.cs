using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;

public class RequestScoreCommand : EventCommand {

    [Inject]
    public IScoreService scoreService { get; set; }
    [Inject]
    public ScrollModel scoreModel { get; set; }

    ////访问这个全局派发器
    //[Inject(ContextKeys.CONTEXT_DISPATCHER)]
    //public IEventDispatcher dispatcher { get; set; }
    //或者直接使用EventCommand，这个类继承自Command，它可以访问全局的派发器



    //在mediator里触发
    public override void Execute() {


        //表示现在不销毁
        Retain();

        //key和value key是事件，value是方法
        //给事件添加一个监听器，监听时实现后面那个方法
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore,OnComplete);
        scoreService.RequestScore("http://xxxxxxx");
    }

    //可以绑定方法，通过Dispather监听
    //IEvent存储的就是参数
    private void OnComplete(IEvent evt) {

        Debug.Log("请求分数结束"+evt.data);

        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore,OnComplete);

        //当分数变改时更新数据类型，把分数存到模型里
        scoreModel.Score = (int)evt.data;

        //派发分数更改事件
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange,evt);
        

        //执行到这里才销毁command
        Release();

    }
}
