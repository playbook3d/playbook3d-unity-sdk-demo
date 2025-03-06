using System;
using System.Collections;
using UnityEngine;
using PlaybookUnitySDK;
using PlaybookUnitySDK.Runtime;
using UnityEngine.Networking;
using System.Collections.Generic;
using PlaybookUnitySDK.Scripts;

public class RetextureDemo : MonoBehaviour
{
    List<IEnumerator> threadPumpList = new List<IEnumerator>();
    
    IEnumerator Retexture(string s)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(s))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                var texture = DownloadHandlerTexture.GetContent(uwr);
                if (this.GetComponent<Renderer>() != null)
                {
                    Material m = this.GetComponent<Renderer>().material;
                    m.SetTexture("_MainTex", texture);
                    this.GetComponent<Renderer>().material = m;
                }
            }
        }
    }
    
    void RetextureFromUrl(string s)
    {
        threadPumpList.Add(Retexture(s));
    }

    private void OnEnable()
    {
        PlaybookSDK.ResultReceived += RetextureFromUrl;
    }

    private void OnDisable()
    {
        PlaybookSDK.ResultReceived -= RetextureFromUrl;
    }
    
    private void Update()
    {
        while (threadPumpList.Count > 0)
        {
            StartCoroutine(threadPumpList[0]);
            threadPumpList.RemoveAt(0);
        }
    }
}
