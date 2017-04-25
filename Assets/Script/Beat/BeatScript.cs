using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class BeatScript : MonoBehaviour
{

    private string selectScoreUrl = "http://192.168.1.27:8500/UforiaWS/scoreOutput.jsp";

    private List<HighScore> highScores = new List<HighScore>();
    // 칸 프리팹 연결
    public GameObject scorePrefap;

    public Transform scoreParent;

    // 기능을 넣을 버튼에 이 함수를 연결해줘야한다
    public void ReciveButton ()
    {
        StartCoroutine("ViewData");
    }

    IEnumerator ViewData ()
    {
        WWW result = DBConn.instance.GET(selectScoreUrl);

        yield return result;

        if ( result.isDone )
        {
            JSONNode jsonData = JSON.Parse(result.text);

            // Debug.Log(jsonData["scoreList"].Count);
            // Debug.Log(jsonData["scoreList"][1]["score_name"].Value);

            //_output.text = "";
            int ranksort = 0;
            for ( int i = 0 ; i < jsonData["scoreList"].Count ; i++ )
            {
                //_output.text += jsonData["scoreList"][i]["score_name"].Value + "\n";
                //_output.text += jsonData["scoreList"][i]["score_score"].Value + "\n";
                string Score_name = jsonData["scoreList"][i]["score_name"].Value;
                string Score_score = jsonData["scoreList"][i]["score_score"].Value;

                highScores.Add(new HighScore(ranksort , Score_name , Score_score));
            }
        }

        //
        for ( int i = 0 ; i < highScores.Count ; i++ )
        {
            GameObject tmpObjec = Instantiate(scorePrefap);

            HighScore tmpScore = highScores[i];

            tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.rank.ToString() , tmpScore.playerName , tmpScore.score);

            tmpObjec.transform.SetParent(scoreParent);
            tmpObjec.GetComponent<RectTransform>().localScale = Vector3.one;
        }
    }
}