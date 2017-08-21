using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCtrl : MonoBehaviour {

    private FSMSystem fsm;

    public Transform[] wayPoints;
    public GameObject npc;
    public GameObject player;

	// Use this for initialization
	void Start () {
        InitFSM();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //初始化状态机
    void InitFSM() {
        fsm = new FSMSystem();//新建一个状态机
        //初始化状态A
        PatrolState patrolState = new PatrolState(wayPoints, npc,player);
        //给状态A添加一个转换条件，即满足这个条件后，由状态A切换到所给的State ID状态
        patrolState.AddTransition(Transition.SawPlayer,StateID.Chase);
        //初始化状态B
        ChaseState chaseState = new ChaseState(npc, player);
        //给状态B加一个转换条件，即满足这个条件后，由状态B切换到所给的State ID状态
        chaseState.AddTransition(Transition.LostPlayer,StateID.Patrol);
        //把这两个状态（有转换条件和下级分支）添加到状态机里
        fsm.AddState(patrolState);
        fsm.AddState(chaseState);

        //设置默认状态
        fsm.StartState(StateID.Patrol);
    }

    //每帧执行
    private void Update()
    {
        //当前状态的更新函数，别的状态的更新函数不调用
        fsm.GetCurrentState.DoUpdate();
    }
}
