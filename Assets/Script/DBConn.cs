using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DBConn : MonoBehaviour
{
    private static DBConn _instance;
    public static DBConn instance { get { return _instance; } }
    private void Awake ()
    {
        _instance = this;
    }

    public WWW GET (String url)
    {
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));

        return www;
    }

    public WWW POST(String url,Dictionary<string,string> post)
    {
        WWWForm form = new WWWForm();
        foreach(KeyValuePair<String,String> post_arg in post )
        {
            form.AddField(post_arg.Key , post_arg.Value);
        }
        WWW www = new WWW(url , form);

        StartCoroutine(WaitForRequest(www));
        return www;
    }

    private IEnumerator WaitForRequest (WWW www)
    {
        yield return www;

        if ( www.error == null )
        {
            Debug.Log("응.." + www.text);
        }
        else
        {
            Debug.Log("응.. 에러" + www.error);
        }
    }
}
