using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//继承服务层定义的功能接口，在这里实现方法
public class ScoreService : IScoreService
{
    public void RequestScore(string url) {
        Debug.Log("Request Score from url"+ url);
        OnReceiveScore();
    }

    public void OnReceiveScore() {
        int score = Random.Range(0,100);

        //这个监听器是在接口里定义的局部监听器,传递score的参数
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore,score);
    }
    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update Score to url" + url + "new score :" + score);

    }

    [Inject]//注入一个局部的监听
    public strange.extensions.dispatcher.eventdispatcher.api.IEventDispatcher dispatcher { get; set; }
}
