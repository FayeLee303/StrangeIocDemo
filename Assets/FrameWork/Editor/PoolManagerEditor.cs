using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PoolManagerEditor {

    [MenuItem("Manager/Create GameObjPoolConfig")]
    static void CreateGameObjPoolList() {
        //创建ScriptableObject类型对象时使用泛型
        GameObjPoolList poolList = ScriptableObject.CreateInstance<GameObjPoolList>();
        string path = PoolManager.PoolConfigPath;
        //创建本地文件,使用工程相对路径，注意加上Assets,注意后缀是asset
        AssetDatabase.CreateAsset(poolList,path);
        AssetDatabase.SaveAssets();
    }
}
