using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextToSpeech : MonoBehaviour {

    // API Key constat 
    private const string API_KEY = "AIzaSyBcYF1v5KKqdx3-97kQ5wrNTL9hHDIRH2Q"
    

    private string url = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=" + API;

    private string request_part1 = "{\\\"audioConfig\\\": {\\\"audioEncoding\\\": \\\"LINEAR16\\\",\\\"effectsProfileId\\\": [\\\"telephony-class-application\\\"],\\\"pitch\\\": \\\"";
    public string pitch = "2.80";
    private string request_part2 = "\\\",\\\"speakingRate\\\": \\\"";
    public string speaking_rate = "1.23";
    private string request_part3 = "\\\"},\\\"input\\\": {\\\"text\\\": \\\"";
    public string text_content = "wasserflasche";
    private string request_part4 = "\\\"},\\\"voice\\\": {\\\"languageCode\\\": \\\"de-DE\\\",\\\"name\\\": \\\"de-DE-Wavenet-A\\\"}}";


    //public void PlaySound()
    //{
    //    WWW www;

    //    //var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };
    //    var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };

    //    var formData = System.Text.Encoding.UTF8.GetBytes(request_part1 + pitch +request_part2 + speaking_rate+request_part3 +text_content +request_part4);

    //    www = new WWW(url, formData, headers);
    //    StartCoroutine(WaitForRequest(www));

    //    //AudioSource AS = GetComponent<AudioSource>();
    //    //AS.clip = www.GetAudioClip(true, true, AudioType.MPEG);
    //    //AS.Play();
    //}
    public void PlaySound()
    {
        StartCoroutine(WaitForRequest());
    }


    IEnumerator WaitForRequest()
    {


        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4);
        Debug.Log(request_part1 + pitch + request_part2 + speaking_rate + request_part3 + text_content + request_part4);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);



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
    }


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
