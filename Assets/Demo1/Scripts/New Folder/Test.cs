using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Cat _cat;
    Mouse _mouse;

    private EventDispatcher evt;

    private void Start()
    {
        _cat = new Cat();
        _mouse = new Mouse();
        //// _cat.CatShoutDelegate += _mouse.MouseRun;//这里是把方法注册到委托里
        // //_cat.CatShout();//这个是调用发射消息的函数

         _cat.CatShoutEventHandler += _mouse.MouseRunEventHandler; //
        evt = GameObject.Find("EventDispather").GetComponent<EventDispatcher>();
        evt.TestEventHandler += Test_1;
    }

    private void OnDestroy()
    {
        _cat.CatShoutEventHandler -= _mouse.MouseRunEventHandler; //这里是把方法从委托里删掉
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //_cat.CatShout();
            _cat.CatShout_1();
            evt.TestEvent();
        }      
    }

    void Test_1(object sender, EventArgs e) {
        evt.AttackEvent();
        Debug.Log("11111111");
    }

}
