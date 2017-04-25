using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {

    public int rank { get; set; }
    public string playerName { get; set; }
    public string score { get; set; }

    public HighScore(int rank,string playerName,string score)
    {
        this.rank = rank;
        this.playerName = playerName;
        this.score = score;
    }
}
