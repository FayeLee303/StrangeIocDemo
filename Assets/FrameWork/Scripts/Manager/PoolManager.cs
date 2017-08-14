using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager {
    private static PoolManager _instance;
    //单例的构造方法
    //交给StrangeIOc在StartCommand里创建会节约一下性能
    public static PoolManager Instance{
        get//get一定要有return
        {
            if (_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance;
        } 
    }

    private static string poolConfigPathPrefix = "Assets / FrameWork / Resources";
    private const string poolConfigPathMiddlefix = "gameObjPool";
    private const string poolConfigPathPostfix = ".asset";

    public static string PoolConfigPath {
        get {
            return poolConfigPathPrefix + poolConfigPathMiddlefix + poolConfigPathPostfix;
        }
    }


    private Dictionary<string, GameObjPool> poolDict;
    //构造方法设置成私有的
    private PoolManager() {
        //读取数据
        GameObjPoolList poolList = Resources.Load<GameObjPoolList>(poolConfigPathMiddlefix);
        //使用字典把资源池名字和资源池List使用键值对储存起来
        poolDict = new Dictionary<string, GameObjPool>();
        foreach (GameObjPool pool in poolList.poolList) {
            poolDict.Add(pool.name,pool);
        }
    }

    public void Init() {
        //Do nothing
    }

    public GameObject GetInst(string poolName) {
        GameObjPool pool;
        if (poolDict.TryGetValue(poolName, out pool))
        {
            return pool.GetInst();
        }
        else {
            Debug.LogWarning("Pool"+poolName+"不存在");
            return null;
        }
    }
}
