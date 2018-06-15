using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{

    //静态字符串保存要加载的场景名字
    public static string LoadingName = "MainScene";
    //静态int类型保存要加载的场景索引
    public static int LoadIndex;

    //引用UI组件
    public UISlider slider;
    public UILabel lable;

    //声明一个异步进度变量
    AsyncOperation asyn;

    //是否加载
    private bool isOk = false;

    // Use this for initialization
    void Start()
    {
        Invoke("PlayLoading", 0.5f);
    }
    public void PlayLoading()
    {
        if (slider == null || lable == null)
        {
            Debug.Log("Error");
        }
        else
        {
            Debug.Log("Successful");
        }
        isOk = true;
        //进入这个场景就立即协程加载新场景
        StartCoroutine("BeginLoading");
    }
    // Update is called once per frame
    void Update()
    {
        if (isOk)
        {
            //更新UI
            if (slider != null)
            {
                if (asyn.progress >= 0.9f)
                    slider.value = 1;
                else
                    slider.value = asyn.progress;
            }
            //加载进度
            if (lable != null)
                lable.text = (slider.value * 100).ToString(".00");
        }
    }

    //加载目标场景的函数
    IEnumerator BeginLoading()
    {
        if (LoadingName == null)
        {     
            asyn = SceneManager.LoadSceneAsync(LoadIndex);
        }
        else
        {
            asyn = SceneManager.LoadSceneAsync(LoadingName);
        }
        yield return asyn;
    }


    //设计一个封装好的静态函数，为了和Unity一致
    //设计以场景名称和场景索引的静态函数


    /// <summary>
    /// 异步加载函数
    /// </summary>
    /// <param name="value">场景名称</param>
    public static void LoadNewScene(string value)
    {
        LoadingName = value;
        SceneManager.LoadScene(LoadingName);
    }

    /// <summary>
    /// 异步加载函数
    /// </summary>
    /// <param name="value">场景索引</param>
    public static void LoadNewScene(int value)
    {
        LoadIndex = value;
        SceneManager.LoadScene(LoadIndex);
    }
}