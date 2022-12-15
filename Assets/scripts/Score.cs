using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Score 
{
    // public string name;
    public float score;
    public string name;

    public Score(float score, string name){
        this.name = name;
        this.score = score;
    }
}
