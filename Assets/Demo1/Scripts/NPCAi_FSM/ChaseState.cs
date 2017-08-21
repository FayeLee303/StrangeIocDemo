using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState {

    private GameObject npc;
    private Rigidbody npcRd;
    private GameObject player;

    public ChaseState(GameObject _npc, GameObject _player)
    {
        stateID = StateID.Chase;
        this.npc = _npc;
        npcRd = this.npc.GetComponent<Rigidbody>();//获得刚体
        this.player = _player;
    }
    public override void DoBeforeEntering()
    {
        Debug.Log("进入" + stateID + "状态");
    }

    public override void DoUpdate()
    {
        //处理该状态的逻辑
        CheckTransition();
        ChaseMove();
    }

    private void CheckTransition() {
        //判断是否丢失
        if (Vector3.Distance(player.transform.position, npc.transform.position) >5 )
        {
            fsm.PerformTrasition(Transition.LostPlayer);//判断满足条件后是否可以转换状态，如果可以就转换至转换条件对应的下一级状态
        }
    }

    private void ChaseMove() {
        npcRd.velocity = npc.transform.forward * 3;//给个速度
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = npc.transform.position.y;//把y轴锁定
        npc.transform.LookAt(targetPosition);//朝向

    }
}
