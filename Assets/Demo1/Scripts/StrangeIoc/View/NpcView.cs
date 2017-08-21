using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcView : View
{
    
    //注入一个局部的事件派发器
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void Init() {
        Debug.Log("Npc Init");
    }

    public void Update()
    {

    }

    public void SawPlayer() {
        Debug.Log("SawPlayer");
    }

    public void LostPlayer() {
        Debug.Log("LostPlayer");
    }


}
