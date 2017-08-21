using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMediator : Mediator
{

    //inject实现自动注入
    [Inject]
    public NpcView npcView { get; set; }

    private EventDispatcher evt;

    public override void OnRegister()
    {
        npcView.Init();
        evt = new EventDispatcher();
        AddEventListenerToNpc();
    }

    public override void OnRemove()
    {
        RemoveEventListenerToNpc();
    }

    private void SawPlayer(GameObject e) {
        npcView.SawPlayer();
    }

    private void LostPlayer(GameObject e) {
        npcView.LostPlayer();
    }

    private void AddEventListenerToNpc() {
        //把方法和委托做绑定
        //当委托事件被发出时，调用其绑定的方法
        //evt.SawPayerEventHandler += SawPlayer; 
        //evt.LostPayerEventHandler += LostPlayer;
    }

    private void RemoveEventListenerToNpc() {
        //把方法和委托解绑
        //evt.SawPayerEventHandler -= SawPlayer;
        //evt.LostPayerEventHandler -= LostPlayer;
    }
}
