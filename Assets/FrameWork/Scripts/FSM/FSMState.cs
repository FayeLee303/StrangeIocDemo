using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//有哪些状态转换的条件
public enum Transition {
    NUllTransition = 0
}

//状态标识符，一个状态只有一个ID且不可重复
public enum StateID
{
    NUllStateID = 0
}

//每一个状态的共有功能
public class FSMState  {
    protected StateID stateID;  //protected是子类可以访问
    public StateID GetStateID {
        get { return stateID; }
    }

    //在某个条件下转换到某个ID的状态
    protected Dictionary<Transition, StateID> mapDict = new Dictionary<Transition, StateID>();

    //添加转换条件
    public void AddTransition(Transition trans, StateID id) {
        if (trans == Transition.NUllTransition || id == StateID.NUllStateID) {
            Debug.LogError("Transition or StateID is null");
            return;
        }
        if (mapDict.ContainsKey(trans)) {
            Debug.LogError("StateId"+stateID + "已经有转换条件"+trans);
            return;
        }
        mapDict.Add(trans,id);
    }

    //删除转换条件
    public void DeleteTransition(Transition trans) {
        if (mapDict.ContainsKey(trans)== false) {
            Debug.LogWarning("转换条件"+trans +"不存在在字典里");
            return;
        }
        mapDict.Remove(trans);
    }

    //如果发生了某个转换条件，看是否能转换成某个状态
    public StateID GetOutPutState(Transition trans) {
        if (mapDict.ContainsKey(trans))
        {
            return mapDict[trans];//这里是返回trans条件下需要转换的状态ID
        }
        else {
            return StateID.NUllStateID;
        }
    }

    //进入当前状态之前要做的事
    public virtual void DoBeforeEntering() {
        //这里可以初始化
    }

    //离开当前状态之前要做的事
    public virtual void DoBeforeLeaving()
    {
        //这里可以清理
    }
}
