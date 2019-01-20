using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;

public class SimplePost : MonoBehaviour {
    public string url;
    public TextAsset imagebyte;
    private string base64image;

    public WWW PostSimple()
    {
        WWW www;

        var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };
        base64image = imagebyte.text;
        Debug.Log(base64image);
        var formData = System.Text.Encoding.UTF8.GetBytes(base64image);

        www = new WWW(url, formData, headers);
        StartCoroutine(WaitForRequest(www));
        return www;
    }

    IEnumerator WaitForRequest(WWW data)
    {
        yield return data; // Wait until the download is done
        if (data.error != null)
        {
            Debug.Log("There was an error sending request: " + data.error + data.text);
        }
        else
        {
            Debug.Log("WWW Request: " + data.text);
        }
    }

}
