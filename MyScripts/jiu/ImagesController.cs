using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesController : MonoBehaviour {

    // Use this for initialization
    private UITweener uiTweener;
    private bool quit = true;
    void Start()
    {
        uiTweener = this.GetComponent<TweenPosition>();

    }
    public void PlayLoop()
    {
        if (quit)
            uiTweener.PlayForward();
        else
            uiTweener.PlayReverse();
        quit = !quit;
    }
}
