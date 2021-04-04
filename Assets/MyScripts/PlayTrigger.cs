using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayTrigger : MonoBehaviour {

    // Use this for initialization
    private UIPlayAnimation uian;
    public float goLeftSpeed;
    public UnityEvent playRight;
    public UnityEvent playLeft;
    public enum whoMode
    {
        NONE,
        stone,
        door,
        library,
        tower
    }
    public whoMode me;
    private void Awake()
    {
        uian = GetComponent<UIPlayAnimation>();
        uian.PlayForward();
        uian.Play(false);
        uian.animator.speed = 0;
    }
    public void PlayForward()
    {
        uian.animator.speed = 1;
        if (uian != null)
            uian.PlayForward();
        if (playRight != null)
            playRight.Invoke();
    }
    public void PlayReverse()
    {
        uian.animator.speed *= goLeftSpeed;
        if (uian != null)
            uian.PlayReverse();
        if (playLeft != null)
            playLeft.Invoke();
    }
    public void SetSpeed(float speed)
    {
        uian.animator.speed = speed;
    }
}
