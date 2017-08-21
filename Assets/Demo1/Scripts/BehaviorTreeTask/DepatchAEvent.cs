using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepatchAEvent : Action {

    private EventDispatcher evt;

    public string EventName;

    //每次执行任务都被调用
    public override void OnStart()
    {
        evt = GameObject.Find("EventDispather").GetComponent<EventDispatcher>();
        
    }

    //任务执行时一直调用,必须有返回值，返回成功或失败则任务结束，返回running则一直调用,频率默认和Unity的帧一致
    public override TaskStatus OnUpdate()
    {
        if (evt != null ) {
            Debug.Log("evt不为空");
        }
        if (EventName == null) return TaskStatus.Failure;
        if (EventName == "SawPlayerEvent")
        {
            evt.SawPlayerEvent();
            Debug.Log("已经把"+EventName+"派发出去了");
        }
        else if (EventName == "LostPlayerEvent")
        {
            evt.LostPlayerEvent();
            Debug.Log("已经把" + EventName + "派发出去了");
        }
        return TaskStatus.Success;
    }
}
