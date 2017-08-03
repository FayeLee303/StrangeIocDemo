using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;

//这是用来绑定的
public class Demo1_MVCSContext : MVCSContext {

    //在这里是给指定一个view，就是context要绑定的物体
    public Demo1_MVCSContext(MonoBehaviour view) : base(view) { }

    //进行绑定映射,这里的绑定都是全局的，必须要使用全局的派发器
    protected override void mapBindings() {
        //model
        //接口和自身做绑定，用自身做构造
        injectionBinder.Bind<ScrollModel>().To<ScrollModel>().ToSingleton();
        //service
        //注入绑定
        //ToSingleton表示这个对象只会在工程里生成一个
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();

        //command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();
       
        //mediator 
        //完成View和Mediator的绑定，绑定之后Mediator的创建交给StrangeIoc来处理，会自动绑定到物体上

        mediationBinder.Bind<CubeView>().To<CubeMediator>();


        //创建一个startCommand开始命令来做一些初始化命令，完成上面的绑定之后立即进行调用
        //事件一般定义为枚举类型，Bind就是绑定，ContextEvent.START是内置的，把StartCommand和它绑定就会自动调用
        //once是只触发一次，执行一次就解绑，不会再执行了
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }

    
}
