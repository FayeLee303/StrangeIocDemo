using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//观察者
public class Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //功能
    public void MouseRun() {
        Debug.Log("Run");
    }

    //处理事件
    public void MouseRunEventHandler(object sender,EventArgs e) {
        Debug.Log("RunRunRun");
    }
}
