using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;


public class Translator : MonoBehaviour {

    public string url;

    private string url_01 = "https://translation.googleapis.com/language/translate/v2/?q=";
    private string url_02 = "&source=en&target=de&key=AIzaSyAGqw4eWE8b1L1FTCuejsVKyM2LFp1rQys";

    public TextToSpeech t2S;

    string pattern = "translatedText\": \"(.*)\"";

    public void Translate()
    {
        //WWW www;

        //var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };

        //var formData = System.Text.Encoding.UTF8.GetBytes("");

        //www = new WWW(url, formData, headers);
        //StartCoroutine(WaitForRequest(www));
        //return www;
        StartCoroutine(GetText());
    }

    public void Translate(string value)
    {
        //WWW www;

        //var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };

        //var formData = System.Text.Encoding.UTF8.GetBytes("");

        //www = new WWW(url, formData, headers);
        //StartCoroutine(WaitForRequest(www));
        //return www;
        StartCoroutine(GetText(value));
    }




    IEnumerator GetText()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator GetText(string value)
    {
        value = url_01 + value + url_02;
        Debug.Log(value);
        value.Replace(" ", "%20");
        using (UnityWebRequest www = UnityWebRequest.Get(value))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
                Regex rgx = new Regex(pattern);
                string translated_word = rgx.Match(www.downloadHandler.text).ToString();
                Debug.Log(translated_word);
                translated_word = translated_word.Substring(18, translated_word.Length - 19);
                Debug.Log(translated_word);
                t2S.text_content = translated_word;
                t2S.GetSound();
            }
        }
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
