using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class AudioWindowEditor : EditorWindow
{

    [MenuItem("Manager/AudioManager")]
    static void CreateWindow()
    {
        AudioWindowEditor window = (AudioWindowEditor)EditorWindow.GetWindow(typeof(AudioWindowEditor), false, "音效管理", true);//创建窗口
        window.Show();
    }

    private string audioName;
    private string audioPath;
    //定义一个键值对的字典，是两个字符串的键值对
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();

    private string savePath;
    private void Awake()
    {
        ////Debug.Log(EditorApplication.applicationPath);
        ////Debug.Log(EditorApplication.applicationContentsPath);
        //Debug.Log(Application.dataPath);

        //savePath = Application.dataPath + "\\FrameWork\\Resources\\audioList.txt";
        //读取数据
        LoadAudioList();

    }

    //窗口被重绘时调用，这个每秒调用十次
    private void OnInspectorUpdate()
    {
        LoadAudioList();
    }

    private void OnGUI()
    {
        //三种绘制方法
        //EditorGUI.TextField(new Rect(0,0,50,50),"输入文字2");
        //EditorGUILayout.TextField("输入文字1", text);
        //GUILayout.TextField("输入文字3");

        //标题栏
        //开始水平布局
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("音效名称");
        EditorGUILayout.LabelField("音效路径");
        EditorGUILayout.LabelField("操作");
        EditorGUILayout.EndHorizontal();//结束水平布局

        //把字典里的数据显示在面板上
        foreach (string key in audioDict.Keys)
        {
            string value;
            //根据Key输出数据到value上
            audioDict.TryGetValue(key, out value);
            //开始水平布局
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(key);
            EditorGUILayout.LabelField(value);
            if (GUILayout.Button("删除"))
            {
                audioDict.Remove(key);
                //删除时保存一下
                SaveAudioList();
                return;//跳出循环
            }
            EditorGUILayout.EndHorizontal();//结束水平布局
        }

        audioName = EditorGUILayout.TextField("音效名字", audioName);
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);
        if (GUILayout.Button("添加音效"))
        {
            //安全检验
            object o = Resources.Load(audioPath);
            if (o == null)
            {
                Debug.LogWarning(audioPath + "路径不正确，添加不成功");
                audioPath = ""; //清空路径
            }
            else
            {
                //判断是否已经存在
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning(audioName + "已经存在，请修改名字");
                }
                else
                {
                    audioDict.Add(audioName, audioPath);
                    //保存
                    SaveAudioList();
                }
            }
        }
    }
 
    private void SaveAudioList()
    {
        StringBuilder str = new StringBuilder();

        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            //存到文本文件里
            str.Append(key + "," + value + "\n");
        }
        File.WriteAllText(AudioManager.AudioTextPath, str.ToString());//这个是覆盖
        //File.AppendAllText(savePath, str.ToString());//这个是追加
    }

    private void LoadAudioList()
    {
        audioDict = new Dictionary<string, string>();//建一个空的字典
        if (!File.Exists(AudioManager.AudioTextPath))
        {
            return;
        }
        else
        {
            string[] lines = File.ReadAllLines(AudioManager.AudioTextPath);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;//判断如果是空行就跳过
                string[] keyvalue = line.Split(',');//按照逗号分隔
                audioDict.Add(keyvalue[0], keyvalue[1]);//添加
            }
        }
    }
}

