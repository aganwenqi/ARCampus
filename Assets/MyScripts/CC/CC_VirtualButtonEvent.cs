using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
public class CC_VirtualButtonEvent : MonoBehaviour {

    // Use this for initialization
    public UnityEvent onButtonPressed;
    public UnityEvent onButtonReleased;

    public float pressedDelay;
    public float releasedDelay;
    void Start () {
	}
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Invoke("OnButtonPressedDelay", pressedDelay);
    }
    void OnButtonPressedDelay()
    {
        if (onButtonPressed != null)
            onButtonPressed.Invoke();
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Invoke("OnButtonReleasedDelay", releasedDelay);
    }
    public void OnButtonReleasedDelay()
    {
        if (onButtonReleased != null)
            onButtonReleased.Invoke();
    }
}
