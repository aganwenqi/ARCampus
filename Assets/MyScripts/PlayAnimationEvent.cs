using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayAnimationEvent : MonoBehaviour {

    // Use this for initialization
    public UnityEvent playRight;
    public UnityEvent playLeft;
    //public bool direction;//false is playRight

    public int manyAnimation; // 播放几个动画算
    private int countan = 0;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Events()
    {
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        countan++;
        if (countan != manyAnimation)
            return;
            
        countan = 0;
        //Debug.Log("雅咩萝");
        //direction = !direction;
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >1.0f)
        {
            if (playRight != null)
                playRight.Invoke();
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime <0.01f)
        {
            if (playLeft != null)
                playLeft.Invoke();
            
        } 
    }
}
