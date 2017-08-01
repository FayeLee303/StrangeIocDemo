using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreService : IScoreService
{
    public void RequestScore(string url) {
        Debug.Log("Request Score from url"+ url);
        OnReceiveScore();
    }

    public void OnReceiveScore() {
        int score = Random.Range(0,100);
    }
    public void UpdateScore(string url,int score) {
        Debug.Log("Update Score to url" + url + "new score :" + score);
    }
}
