using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    // public ButtonScript _input;
    // public ButtonScript _output;
    public Text _output;


    // http://192.168.1.27:8500/UforiaWS/scoreInput.jsp
    // http://192.168.1.27:8500/UforiaWS/scoreOutput.jsp

    // private string inputScoreUrl = "";
    private string selectScoreUrl = "http://192.168.1.27:8500/UforiaWS/scoreOutput.jsp";

    // public void inputScoreButton (){}

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

            Debug.Log(jsonData["scoreList"].Count);
            Debug.Log(jsonData["scoreList"][1]["score_name"].Value);

            _output.text = "";
            for(int i = 0 ; i < jsonData["scoreList"].Count ;i++ )
            {
                _output.text += jsonData["scoreList"][i]["score_name"].Value + "\n";
                _output.text += jsonData["scoreList"][i]["score_score"].Value + "\n";
            }
        }
    }
}
