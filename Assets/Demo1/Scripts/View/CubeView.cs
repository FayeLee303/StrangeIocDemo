using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//view只跟mediator进行交互，mediator负责跟外界交互

public class CubeView : View {

    private Text scoreText;

    //最好不要用Start，而是用init，但是init不是自动调用的，需要在其他地方实现它
    public void Init(){
        scoreText = GetComponentInChildren<Text>();
    }

    public void Update()
    {
        //transform.Translate(new Vector3(Random.Range(-1,1),Random.Range(-1,1),0));
    }

    private void OnMouseDown()
    {
        //Unity自带的函数，
        Debug.Log("OnMouseDown");
    }

    public void UpdateScore(int score) {
        //只负责显示不负责操作
        scoreText.text = score.ToString();
    }
}
