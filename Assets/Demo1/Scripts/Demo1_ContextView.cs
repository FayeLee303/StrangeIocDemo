using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这是root，用来启动整个框架
public class Demo1_ContextView : ContextView {

    void Awake()
    {
        this.context = new Demo1_MVCSContext(this);//构造一个Context，this就是contextView
        //context.Start();//启动整个框架
        //启动框架后就会进行mapBindings绑定
    }


}
