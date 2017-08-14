using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager  {

    //static是静态变量，const是常量
    private static string audioTextPathPrefix = Application.dataPath + "\\FrameWork\\Resources\\";
    private const string audioTextPathMiddlefix = "audioList";
    private const string audioTextPathPostfix = ".txt";
    public static string AudioTextPath {
        get{
            return audioTextPathPrefix + audioTextPathMiddlefix + audioTextPathPostfix;
        }
    }
    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

    public bool isMute = false;//是否静音
    public void Init()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip() {
        audioClipDict = new Dictionary<string, AudioClip>();//清空字典
        TextAsset ta =  Resources.Load<TextAsset>(audioTextPathMiddlefix);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;//判断如果是空行就跳过
            string[] keyvalue = line.Split(',');//按照逗号分隔
            string key = keyvalue[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalue[1]);
            audioClipDict.Add(key,value);
        }
    }

    public void Play(string name) {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name,out ac);
        if (ac != null) {
            AudioSource.PlayClipAtPoint(ac,Vector3.zero);
        }
    }

    public void PlayAtPosition(string name,Vector3 position)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }

    
}
