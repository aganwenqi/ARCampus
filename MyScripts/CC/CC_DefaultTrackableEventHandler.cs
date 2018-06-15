using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
public class CC_DefaultTrackableEventHandler : DefaultTrackableEventHandler {


    public enum Pattern
    {
        NONE,
        BASE,
        USER
    }

    public Pattern pattern = Pattern.NONE;

    public GameObject[] childs;//All the childs

    public UnityEvent onFound;
    public UnityEvent onLost;
    protected override void OnTrackingFound()
    {
        if (pattern == Pattern.NONE)
        {
            //static
        }
        else if (pattern == Pattern.BASE)
        {
            base.OnTrackingFound();
        }
        else if (pattern == Pattern.USER)
        {
            ShowAndHide(true);
        }
        if (onFound != null)
            onFound.Invoke();
    }
    protected override void OnTrackingLost()
    {
        if (pattern == Pattern.NONE)
        {
            //static
        }
        else if (pattern == Pattern.BASE)
        {
            base.OnTrackingLost();
        }
        else if (pattern == Pattern.USER)
        {
            ShowAndHide(false);
        }
        if (onLost != null)
            onLost.Invoke();
    }

    //if type is true,That Show,anthor Hide
     public void ShowAndHide(bool type)
    {
        foreach (var i in childs)
        {
            i.SetActive(type);
            //Debug.Log("德玛西亚:" + i.name);
        }    
    }
}
