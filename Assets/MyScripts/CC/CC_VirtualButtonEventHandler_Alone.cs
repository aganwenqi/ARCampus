using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CC_VirtualButtonEventHandler_Alone : VirtualButtonEventHandler {

    #region PUBLIC_METHODS
    public float delayPressed;//延时通知
    private float delaycount = 0;
    private bool delayQuit = false;
	public override void OnButtonPressed(VirtualButtonBehaviour vb)
	{
        if (delayQuit == true) return;

        delayQuit = true;
        //StartCoroutine(DelayPressed());
        base.OnButtonPressed(vb);
        var ar = vb.GetComponent<CC_VirtualButtonEvent>();
        if (ar)
            ar.OnButtonPressed(vb);
    }
    private IEnumerator DelayPressed()
    {
        yield return new WaitForSeconds(delayPressed);
        delayQuit = false;
        Debug.Log("dsfsdf");
    }
    private void Update()
    {
        if (delayQuit == true)
        {
            delaycount += Time.deltaTime*0.9f;
            if (delaycount >= delayPressed)
            {
                delayQuit = false;
                delaycount = 0;
            }
        }

    }
    public override void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        base.OnButtonReleased(vb);
        var ar = vb.GetComponent<CC_VirtualButtonEvent>();
        if (ar)
            ar.OnButtonReleased(vb);
    }
    #endregion // PRIVATE METHODS
}
