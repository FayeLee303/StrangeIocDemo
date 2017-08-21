using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

//这里放所有可能需要派发的事件
public class EventDispatcher : MonoBehaviour {

    //定义委托事件,它定义了可以代表的方法的类型

    /**事件*/
    //public delegate void EventHandler(GameObject e);
    /**碰撞检测*/
    public delegate void CollisionHandler(GameObject e, Collision c);
    /**触发器检测*/
    public delegate void TriggerHandler(GameObject e, Collider other);
    /**控制器碰撞检测*/
    public delegate void ControllerColliderHitHandler(GameObject e, ControllerColliderHit hit);
    /**新关卡被加载进来*/
    public delegate void LevelWasLoadedHandler(GameObject e, int level);

    //看到玩家事件
    public event EventHandler SawPayerEventHandler;
    public virtual void SawPlayerEvent()
    {
        if (SawPayerEventHandler != null)//如果有方法注册委托变量
        {
            //SawPayerEventHandler(this.gameObject);//通过委托调用方法
            Debug.Log("SawPlayerEvent派发成功");
        }
    }

    //丢失玩家视野事件
    public event EventHandler LostPayerEventHandler;
    public virtual void LostPlayerEvent()
    {
        if (LostPayerEventHandler != null)//如果有方法注册委托变量
        {
           // LostPayerEventHandler(this.gameObject);//通过委托调用方法
            Debug.Log("LostPlayerEvent派发成功");
        }
    }

    //发动攻击事件
    public event EventHandler AttackEventHandler;
    public virtual void AttackEvent()
    {
        if (AttackEventHandler != null)//如果有方法注册委托变量
        {
            //AttackEventHandler(this.gameObject);//通过委托调用方法
            Debug.Log("AttackEvent派发成功");
        }
    }

    //测试
    public event EventHandler TestEventHandler;
    public void TestEvent()
    {
        TestEventHandler(this,new EventArgs()); //这句是分发事件
    }

}
