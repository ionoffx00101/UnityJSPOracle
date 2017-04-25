using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // 화면에 있는 UI연결
    public Text _output;
    public InputField InputFieldName;
    public InputField InputFieldScore;

    // http://192.168.1.27:8500/UforiaWS/scoreInput.jsp
    // http://192.168.1.27:8500/UforiaWS/scoreOutput.jsp

    private string inputScoreUrl = "http://192.168.1.27:8500/UforiaWS/scoreInput.jsp";
    private string selectScoreUrl = "http://192.168.1.27:8500/UforiaWS/scoreOutput.jsp";

    // inputbtn이 연결되는 함수
    public void inputScoreButton ()
    {
        string inputName = InputFieldName.text;
        string inputScore = InputFieldScore.text;

        //Debug.Log(inputName + " , " + inputScore);

        // 이제 넣어야함
        // 주소 만들어주기
        string data = inputScoreUrl + "?score_name=" + inputName + "&score_score=" + inputScore;
        DBConn.instance.GET(data);

        // ?
        UnityEngine.PlayerPrefs.SetString("stringKey" , "abc");
        UnityEngine.PlayerPrefs.SetFloat("floatKey" , 2.0f);
    }

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

            _output.text = "";
            for ( int i = 0 ; i < jsonData["scoreList"].Count ; i++ )
            {
                _output.text += jsonData["scoreList"][i]["score_name"].Value + "\n";
                _output.text += jsonData["scoreList"][i]["score_score"].Value + "\n";
            }
        }
    }
}
