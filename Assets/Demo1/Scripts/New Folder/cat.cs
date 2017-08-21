using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//被观察者
public class Cat : MonoBehaviour {

    //   EventTask task;

    //   // Use this for initialization
    //   void Start () {

    //       task.SendEvent += this.SeePlayerAndChase;
    //   }

    //// Update is called once per frame
    //void Update () {

    //}

    //   public void SeePlayerAndChase()
    //   {
    //       Debug.Log("cat");
    //   }

    void Start()
    {

    }


    ////状态发生改变
    //public void CatShout()
    //{
    //    Debug.Log("Shout");
    //    if (CatShoutDelegate!=null) {
    //        CatShoutDelegate();//调用委托
    //    }
    //}

    //定义了一个委托
    //public Action CatShoutDelegate;

    //定义一个事件委托
    public event EventHandler CatShoutEventHandler;


    ////定义了一个事件
    //protected virtual void CatShoutEvent(EventArgs e) {

    //    EventHandler handler = CatShoutEventHandler;
    //    if (handler != null) {
    //        handler(this,e);
    //    }
    //}

    //发送事件函数
    public void CatShout_1() {
        Debug.Log("ShoutShoutShout");
       // CatShoutEvent(new EventArgs()); //这句是发射信息
        CatShoutEventHandler(this,new EventArgs()); //这句是分发事件
    }
}
