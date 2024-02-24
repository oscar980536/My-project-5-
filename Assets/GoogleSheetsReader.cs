using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GoogleSheetsReader : MonoBehaviour
{
    // 替换为你的 Google Apps Script URL
    public string googleSheetUrl = "https://script.google.com/macros/s/AKfycbxuCA7HVaHrLwMBLKpjDWPa0LhA0Oatp4n4Uh0v1zxVTgbjpM8uwVnsQ4M-m4eDZ7g1/exec";

    void Start()
    {
        StartCoroutine(DownloadDataFromGoogleSheet());
    }

    IEnumerator DownloadDataFromGoogleSheet()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(googleSheetUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download data from Google Sheets: " + webRequest.error);
            }
            else
            {
                // 解析 JSON 数据并处理
                string jsonData = webRequest.downloadHandler.text;
                Debug.Log("Received data from Google Sheets: " + jsonData);

                // 在这里进行进一步处理，例如将 JSON 数据转换为对象或者进行其他操作
            }
        }
    }
}
