using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//把初始化放在StartCommand里
public class LocalizationManager  {

    //单例模式
    private static LocalizationManager _instance;
    public static LocalizationManager Instance {
        get {
            if (_instance == null) {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";

    public const string Language = English; //这时候Language存的是一个路径

    private Dictionary<string, string> LanDict;
   
    //构造函数
    public LocalizationManager() {
        LanDict = new Dictionary<string, string>();//安全起见初始化
        TextAsset ta = Resources.Load<TextAsset>(Language);
        string[] lines = ta.text.Split('\n'); //根据换行符切分

        foreach (string line in lines) {
            if (string.IsNullOrEmpty(line) == false)
            {
                string[] keyvalues = line.Split('-');//根据连接符拆分
                LanDict.Add(keyvalues[0], keyvalues[1]);//存到字典里
            }
        }

    }

    //初始化
    public void Init() {
        //Do Nothing
    }

    //读取数据
    public string GetValue(string key) {
        string value;
        LanDict.TryGetValue(key,out value);
        return value;
    }
}
