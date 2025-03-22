using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
public class NativeShareButton : MonoBehaviour
{
    public string text = "I challenge you to beat my high score! ";
    public string url = "https://unity.com/ru";
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnShareButtonClick);
    }
    public void OnShareButtonClick()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();
        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());
        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath)
        .SetSubject("Subject goes here").SetText(text).SetUrl(url)
        .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ",selected app: " + shareTarget))
        .Share();
    }
}