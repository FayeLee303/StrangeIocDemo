using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState {

    private Transform[] wayPoints;
    private GameObject npc;
    private Rigidbody npcRd;
    private int targerWayPoint;//当前在哪个点附近
    private GameObject player;

    //构造方法
    public PatrolState(Transform[] p,GameObject _npc,GameObject _player) {
        stateID = StateID.Patrol;
        wayPoints = p;
        this.npc = _npc;
        npcRd = this.npc.GetComponent<Rigidbody>();//获得刚体
        this.player = _player;
        targerWayPoint = 0;
    }
    public override void DoBeforeEntering()
    {
        Debug.Log("进入"+ stateID+"状态");
    }

    public override void DoUpdate()
    {
        //处理该状态的逻辑
        CheckTransition();
        PatrolMove();
    }

    //检查是否满足转换条件
    private void CheckTransition() {
        //判断是否看到
        if (Vector3.Distance(player.transform.position,npc.transform.position)<5) {
            fsm.PerformTrasition(Transition.SawPlayer);//判断满足条件后是否可以转换状态，如果可以就转换至转换条件对应的下一级状态
        }
    }

    private void PatrolMove() {
        npcRd.velocity = npc.transform.forward * 3;//给个速度
        Transform targetTrans = wayPoints[targerWayPoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;//把y轴锁定
        npc.transform.LookAt(targetPosition);//朝向
        //判断接近目标点
        if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
        {
            targerWayPoint++;
            targerWayPoint %= wayPoints.Length;//不能超过数组的长度
        }
    }

}
