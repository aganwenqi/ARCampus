using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;
public class ScreenShot : MonoBehaviour {

    
    // Use this for initialization
    public Camera ARCamera;
	void Start () {
	}
    [DllImport("__Internal")]
    private static extern void _SavePhotos(string readAddr); 

    public void OnScreenShotClick()
    {
        
        System.DateTime now = System.DateTime.Now;
        string time = now.ToString().Replace('/', '.');
        var fileName = "AR" + time + ".png";
        //string fileName = "AR.png";

        if(Application.platform == RuntimePlatform.Android)
        {
            //包含UI
            /*
            Texture2D texture = new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,false);
            texture.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0);

            texture.Apply();

            byte[] bytes = texture.EncodeToPNG();

            string destination = "/sdcard/DCIM/Screenshots";

            if(!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            string pathSave = destination + "/" + fileName;

            File.WriteAllBytes(pathSave,bytes);
             */

            //不包含UI

            RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 1);
            ARCamera.targetTexture = rt;
            ARCamera.Render();

            RenderTexture.active = rt;

            Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();

            ARCamera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);

            byte[] bytes = texture.EncodeToPNG();

            /*
            string destination = "/sdcard/DCIM/ARphoto";

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }*/
            string path = Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android"));
            string pathSave = path + "/Pictures/" + fileName;

            System.IO.File.WriteAllBytes(pathSave, bytes);

            string[] paths = new string[1];
            paths[0] = path;
            ScanFile(paths);
        }
        else if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 1);
            ARCamera.targetTexture = rt;
            ARCamera.Render();

            RenderTexture.active = rt;

            Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();

            ARCamera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);

            byte[] bytes = texture.EncodeToPNG();

            var destination = Application.persistentDataPath+ "/" + fileName;



            System.IO.File.WriteAllBytes(destination, bytes);

            UnityEngine.ScreenCapture.CaptureScreenshot(fileName);
            _SavePhotos(destination);

        }
    }
    //刷新图片，显示到相册中
    void ScanFile(string[] path)
    {
        using (AndroidJavaClass PlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject playerActivity = PlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");
            using (AndroidJavaObject Conn = new AndroidJavaObject("android.media.MediaScannerConnection", playerActivity, null))
            {
                Conn.CallStatic("scanFile", playerActivity, path, null, null);
            }
        }
    }
}
