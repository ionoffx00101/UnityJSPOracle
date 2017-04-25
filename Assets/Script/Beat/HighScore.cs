using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {

    public string rank { get; set; }
    public string playerName { get; set; }
    public string score { get; set; }

    public HighScore(string rank ,string playerName,string score)
    {
        this.rank = rank;
        this.playerName = playerName;
        this.score = score;
    }
}
