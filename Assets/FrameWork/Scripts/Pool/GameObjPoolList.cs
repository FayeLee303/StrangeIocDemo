using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//管理所有的资源池
public class GameObjPoolList : ScriptableObject {
    //继承自ScriptableObject表示把这个类变成可以自定义资源配置的文件
    public List<GameObjPool> poolList;
}
