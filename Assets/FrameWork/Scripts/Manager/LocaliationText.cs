using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//挂在物体身上
public class LocaliationText : MonoBehaviour {

    public string key;
	// Use this for initialization
	void Start () {
        string value = LocalizationManager.Instance.GetValue(key);
        GetComponent<Text>().text = value;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
