using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongQiController : MonoBehaviour {

    private Animator anim;
    private Vector3 ve;
	void Awake () {
        anim = this.GetComponent<Animator>();
        ve = this.transform.localScale;
    }

    private void OnEnable()
    {
        anim.enabled = false;

        Invoke("Delay", 2.3f);
        
    }
    void Delay()
    {
        this.transform.localScale = ve;
        anim.enabled = true;
        anim.speed = 1;
        Invoke("ZanTing", 1.9f);
    }
    void ZanTing()
    {
        anim.speed = 0;
    }
    private void OnDisable()
    {
        this.transform.localScale = Vector3.zero;
        StopAllCoroutines();
    }
}
