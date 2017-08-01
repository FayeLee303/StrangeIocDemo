using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;

//这是用来绑定的
public class Demo1_MVCSContext : MVCSContext {

    //在这里是给指定一个view，就是context要绑定的物体
    public Demo1_MVCSContext(MonoBehaviour view) : base(view) { }

    //进行绑定映射
    protected override void mapBindings() {
        //model

        //service

        //command

        //mediator 这个其实就是view


        //创建一个startCommand开始命令来做一些初始化命令，完成上面的绑定之后立即进行调用
        //事件一般定义为枚举类型，Bind就是绑定，ContextEvent.START是内置的，把StartCommand和它绑定就会自动调用
        commandBinder.Bind(ContextEvent.START).To<StartCommand>();
    }

    
}
