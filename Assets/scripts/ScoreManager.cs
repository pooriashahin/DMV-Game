using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderBy(x=>x.score);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
        // SaveScore();
    }
    public void OnDestroy()
    {
        SaveScore();
    }
    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }
}
