using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这是一个接口
public interface IScoreService
{

    void RequestScore(string url);//请求分数
    void OnReceiveScore();//收到服务器端发过来的分数
    void UpdateScore(string url, int score);//更新分数

    //在服务层的接口里定义监听器
    IEventDispatcher dispatcher { get; set; }
}
