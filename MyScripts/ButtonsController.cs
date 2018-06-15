using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour {

    // Use this for initialization
    private UITweener uiTweener;
    private bool quit = true;
    public GameObject ar;
    public Camera arCamera;
	void Start () {
        uiTweener = this.GetComponent<TweenPosition>();

        TweenPosition pos = this.GetComponent<TweenPosition>();
        float x = this.GetComponent<RectTransform>().sizeDelta.x;
        pos.to = new Vector3(
            pos.to.x- (x*1.4f),
            pos.to.y,
            pos.to.z
            );
        Invoke("DelayAr",1f);
        Invoke("DelayArCamera", 0.2f);
    }
    void DelayArCamera()
    {
        //arCamera.enabled = false;
    }
    void DelayAr()
    {
        ar.SetActive(false);
       // arCamera.enabled = true;
    }
    public void PlayLoop()
    {
        if (quit)
        {
            uiTweener.PlayForward();
            ar.SetActive(true);
        }
        else
        {
            uiTweener.PlayReverse();
            ar.SetActive(false);
        }  
        quit = !quit;
    }
}
