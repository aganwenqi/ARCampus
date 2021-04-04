using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllModeController : MonoBehaviour {

    // Use this for initialization
    
   // public play stone;
    private PlayTrigger[] modes;

    //private whoMode laser = whoMode.NONE;
    private PlayTrigger.whoMode laser = PlayTrigger.whoMode.NONE;

    private bool isOk = true;
    private void Awake()
    {
        modes = GetComponentsInChildren<PlayTrigger>();
        
        var events = GetComponentsInChildren<PlayAnimationEvent>();
        foreach (var i in events)
        {
            i.playLeft.AddListener(PlayLeftOk);
            i.playRight.AddListener(PlayRightOk);
        }
        foreach (var i in modes)
        {
            i.gameObject.SetActive(false);
        }
    }
    public void Play(int who)
    {
        
        if (who == (int)laser || !isOk) return;//相同不执行
        
        if (laser == PlayTrigger.whoMode.NONE)//No plaed
        {
            foreach (var i in modes)
            {
                if ((int)i.me == who)
                {
                    i.gameObject.SetActive(true);
                    i.PlayForward();
                    break;
                }
                else
                {
                    if(i.gameObject.activeSelf)
                        i.gameObject.SetActive(false);
                }
            }
        }
        else//hava mode
        {
            
            foreach (var i in modes)
            {
                if (i.me == laser)
                {
                    i.PlayReverse();
                    isOk = false;
                    break;
                }
            }
        }
            laser = (PlayTrigger.whoMode)who;
    }

    //Hava one of playLeft Ok and playRight Ok
    void PlayLeftOk()
    {
        foreach (var i in modes)
        {
            if (i.me == laser)
            {
                i.gameObject.SetActive(true);
                i.PlayForward();
                isOk = true;
               // break;
            }
            else
            {
                if (i.gameObject.activeSelf)
                    i.gameObject.SetActive(false);
            }
        }
    }
    void PlayRightOk()
    {
        foreach (var i in modes)
        {
            if (i.me == laser)
            {
                i.gameObject.SetActive(true);
                i.PlayForward();
                isOk = true;
                // break;
            }
            else
            {
                if (i.gameObject.activeSelf)
                    i.gameObject.SetActive(false);
            }
        }
    }
}
