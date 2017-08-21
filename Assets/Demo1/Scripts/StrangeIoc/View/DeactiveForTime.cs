using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveForTime : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        Invoke("Deactive",3);//3秒后执行该函数
	}
	

    void Deactive() {
        this.gameObject.SetActive(false);
    }
}
