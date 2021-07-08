using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TexturesFromWeb : MonoBehaviour
{

    public string textureURL;

    [System.Obsolete]
    public void setTextureFromWeb()
    {
        string textureurl = textureURL;
        StartCoroutine(DownloadTexture(textureurl));
    }

    [System.Obsolete]
    IEnumerator DownloadTexture(string textureurl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(textureurl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}