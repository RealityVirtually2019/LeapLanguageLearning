using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using WWUtils.Audio;
using System.Text.RegularExpressions;


public class TextToSpeech : MonoBehaviour {

// API Key constat 




public TextAsset jsonString;
public TextAsset aduio64String;

private string url = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyAGqw4eWE8b1L1FTCuejsVKyM2LFp1rQys";

public TextAsset request_part1;

//private string request_part1 = "{\\\"audioConfig\\\": {\\\"audioEncoding\\\": \\\"LINEAR16\\\",\\\"effectsProfileId\\\": [\\\"telephony-class-application\\\"],\\\"pitch\\\": \\\"";
public string pitch = "2.80";
public TextAsset request_part2;
public string speaking_rate = "1.23";
public TextAsset request_part3;
public string text_content = "wasserflasche";
public TextAsset request_part4;


string testString = "{\n  \"audioContent\": \"UklGRurLAABXQVZFAAAAAAA\"AAAAAAAAAAAAA";
string pattern = "\": \"(.*)\"";
private string result;




//public void PlaySound()
//{

//    WWW www;

//    //var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };
//    var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };

//    var formData = System.Text.Encoding.UTF8.GetBytes(request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4);

//    www = new WWW(url, formData, headers);
//    StartCoroutine(WaitForRequest(www));
//
//    //AudioSource AS = GetComponent<AudioSource>();
//    //AS.clip = www.GetAudioClip(true, true, AudioType.MPEG);
//    //AS.Play();
//}

public void PlaySound()
{
    Debug.Log(System.Convert.FromBase64String(aduio64String.text));
    WAV wav = new WAV(System.Convert.FromBase64String(aduio64String.text));

    Debug.Log(wav);
    AudioClip audioClip = AudioClip.Create("testSound", wav.SampleCount, 1, wav.Frequency, false, false);
    audioClip.SetData(wav.LeftChannel, 0);
    AudioSource AS = GetComponent<AudioSource>();
    AS.clip = audioClip;
    AS.Play();
}

public void GetSound(){
//    StartCoroutine(WaitForRequest());
//}


//IEnumerator WaitForRequest()
//{
    ////Regex rgx = new Regex(pattern);
    ////string value = rgx.Match(testString).ToString();
    ////value = value.Substring(3, value.Length - 4);
   
    StartCoroutine(Post());
}

IEnumerator Post()
{
    var request = new UnityWebRequest(url, "POST");


    string target = request_part1.text + pitch + request_part2.text + speaking_rate + request_part3.text + text_content + request_part4.text;
    //string target = jsonString.text;
    Debug.Log(target);
    byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(target);
    //byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonString.text);
    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    request.SetRequestHeader("Content-Type", "application/json");

    yield return request.Send();

    Debug.Log("Status Code: " + request.responseCode);
    Debug.Log(request.downloadHandler.text);

    result = request.downloadHandler.text;


    Regex rgx = new Regex(pattern);
    string value = rgx.Match(result).ToString();
    value = value.Substring(4, value.Length - 5);

    Debug.Log(value);
    WAV wav = new WAV(System.Convert.FromBase64String(value));
    
    Debug.Log(wav);
    AudioClip audioClip = AudioClip.Create("testSound", wav.SampleCount, 1, wav.Frequency, false, false);
    audioClip.SetData(wav.LeftChannel, 0);
    AudioSource AS = GetComponent<AudioSource>();
    AS.clip = audioClip;
    AS.Play();

    //AudioSource AS = GetComponent<AudioSource>();
    ////AS.clip = www.GetAudioClip(true, true, AudioType.MPEG);
    //AS.clip = DownloadHandlerAudioClip.GetContent(request);
    //AS.Play();



}

//IEnumerator WaitForRequest()
//{
//    var requestString = System.Text.Encoding.UTF8.GetBytes(jsonString.text);
//    Debug.Log(requestString);

//    using (UnityWebRequest www = UnityWebRequest.Post(url, requestString))
//    {
//        yield return www.SendWebRequest();

//        if (www.isNetworkError || www.isHttpError)
//        {
//            Debug.Log(www.error);
//        }
//        else
//        {
//            Debug.Log("Form upload complete!");
//            Debug.Log(www.downloadHandler.text);
//        }
//    }


//    //var request = new UnityWebRequest(url, "POST");
//    ////byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4);
//    //Debug.Log(request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4);
//    //request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
//    //request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
//    //request.SetRequestHeader("Content-Type", "application/json");

//    //yield return request.SendWebRequest();
//    //Debug.Log("Status Code: " + request.responseCode);
//    //Debug.Log(request.downloadedBytes);



//    //var form = System.Text.Encoding.UTF8.GetBytes(request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4);
//    ////var form = request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4;
//    //using (UnityWebRequest www = UnityWebRequest.Put(url, form))
//    //{
//    //    www.uploadHandler = (UploadHandler)new UploadHandlerRaw(form);
//    //    www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
//    //    www.SetRequestHeader("Content-Type", "application/json");
//    //    yield return www.SendWebRequest();

//    //    if (www.isNetworkError || www.isHttpError)
//    //    {
//    //        Debug.Log(www.error);
//    //    }
//    //    else
//    //    {
//    //        Debug.Log("Form upload complete!");
//    //        Debug.Log(www.responseCode);
//    //    }
//    //}
//}


    //var form = System.Text.Encoding.UTF8.GetBytes(request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4);
    ////var form = request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4;
    //using (UnityWebRequest www = UnityWebRequest.Put(url, form))
    //{
    //    www.uploadHandler = (UploadHandler)new UploadHandlerRaw(form);
    //    www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //    www.SetRequestHeader("Content-Type", "application/json");
    //    yield return www.SendWebRequest();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.Log(www.error);
    //    }
    //    else
    //    {
    //        Debug.Log("Form upload complete!");
    //        Debug.Log(www.responseCode);
    //    }
    //}




//IEnumerator WaitForRequest(WWW data)
//{
//    yield return data; // Wait until the download is done
//    if (data.error != null)
//    {
//        Debug.Log("There was an error sending request: " + data.error);
//    }
//    else
//    {
//        Debug.Log("WWW Request: " + data.text);
//    }
//}

}
