using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]//可以序列化
public class GameObjPool  {
    [SerializeField]//可以在面板上被编辑，相当于Public
    public string name;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int maxAmount;//最大容量

    [NonSerialized]//这个不需要被序列化
    private List<GameObject> goList = new List<GameObject>();

    //从资源池中获取一个实例
    public GameObject GetInst() {
        foreach (GameObject go in goList) {
            if (go.activeInHierarchy == false) { //判断是否禁用
                go.SetActive(true);
                return go;
            }
        }
        if (goList.Count >= maxAmount) {
            //判断池子是否满了，满了就销毁第一个
            GameObject.Destroy(goList[0]);
            goList.RemoveAt(0);
        }

        //实例化一个新的
        GameObject temp = GameObject.Instantiate(prefab) as GameObject;
        goList.Add(temp);

        return temp;
    }
}
