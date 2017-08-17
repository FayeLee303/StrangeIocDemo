using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状态机管理类，有限状态机系统类
public class FSMSystem  {
    //用字典保存当前状态机里有哪些状态
    private Dictionary<StateID,FSMState> statesDict;

    private FSMState currentState;//状态机里的当前状态
    //获取
    public FSMState GetCurrentState {
        get {
            return currentState;
        }
    }

    //构造函数
    public FSMSystem() {
        statesDict = new Dictionary<StateID, FSMState>();
    }

    //向状态机里添加状态
    public void AddState(FSMState state) {
        if (state == null) {
            Debug.LogError("你想添加的状态"+state+"是空的");
            return;
        }
        if (statesDict.ContainsKey(state.GetStateID)) {
            //看字典里是否已经有想要添加的状态ID
            Debug.LogError("你想添加的状态"+state.GetStateID+"已经存在");
            return;
        }
        statesDict.Add(state.GetStateID,state);
    }
    //向状态机里删除状态
    public void DeleteState(FSMState state) {
        if (state == null)
        {
            Debug.LogError("你想添加的状态" + state + "是空的");
            return;

        }
        if (statesDict.ContainsKey(state.GetStateID) == false)
        {
            //看字典里是否已经有想要添加的状态ID
            Debug.LogError("你想添加的状态" + state.GetStateID + "已经被删除");
            return;
        }
        statesDict.Remove(state.GetStateID);
    }

    //根据条件转换状态
    public void PerformTrasition(Transition trans) {
        if (trans == Transition.NUllTransition) {
            Debug.LogError("空条件不能做转换条件");
        }

        //传过来一个条件，判断这个条件能不能转换成另一个状态
        //GetOutPutState方法返回的是一个StateID值
        StateID id = GetCurrentState.GetOutPutState(trans);
        if (id == StateID.NUllStateID)
        {
            Debug.Log("给的条件无效，没有符合条件的转换");
            return;
        }
        else {
            FSMState state;
            statesDict.TryGetValue(id, out state);//根据ID得到一个state
            GetCurrentState.DoBeforeEntering();
            currentState = state; //当前状态切换至新的状态
            GetCurrentState.DoBeforeLeaving();
        }
    }
}
