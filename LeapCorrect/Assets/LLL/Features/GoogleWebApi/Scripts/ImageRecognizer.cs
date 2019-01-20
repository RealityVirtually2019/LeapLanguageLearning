using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Text.RegularExpressions;

public class ImageRecognizer : MonoBehaviour {

    public Translator translator;
    public Texture2D targetTexture;
    public TextAsset imagebyte;
    public const string API_KEY = "AIzaSyBcYF1v5KKqdx3-97kQ5wrNTL9hHDIRH2Q";

    private string url = "https://vision.googleapis.com/v1/images:annotate?key=" + API_KEY;
    private string request_first_part = "{\"requests\": [{\"image\": {\"content\": \"";
    private string request_final_part = "\"},\"features\": [{\"type\": \"LABEL_DETECTION\"}]}]}";
    private string base64image;

    string pattern = "description\": \"(.*)\"";


    public WWW UpdloadScreen()
    {
        WWW www;
        
        var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };
        base64image = imagebyte.text;
        Debug.Log(base64image);
        var formData = System.Text.Encoding.UTF8.GetBytes(request_first_part+base64image +request_final_part);

        www = new WWW(url, formData, headers);
        StartCoroutine(WaitForRequest(www));
        return www;
    }


    IEnumerator WaitForRequest(WWW data)
    {
        yield return data; // Wait until the download is done
        if (data.error != null)
        {
            Debug.Log("There was an error sending request: " + data.error);
        }
        else
        {
            Debug.Log(data.text);
            Regex rgx = new Regex(pattern);
            string value = rgx.Match(data.text).ToString();
            Debug.Log(value);
            value = value.Substring(15, value.Length - 16);
            translator.Translate(value);

        }
    }

}
