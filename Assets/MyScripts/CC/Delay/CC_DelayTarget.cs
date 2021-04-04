using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_DelayTarget : MonoBehaviour {

    // public void Delay
    public void Play(float time)
    {
        Invoke("DelayHide", time);
    }
    void DelayHide()
    {
        this.gameObject.SetActive(false);
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
