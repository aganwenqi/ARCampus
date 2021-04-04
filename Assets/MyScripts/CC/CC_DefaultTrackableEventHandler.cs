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

    ~CC_DefaultTrackableEventHandler()
    {
        //StopAllCoroutines();
    }
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
            StopCoroutine("OnTrackingFoundYied");
            StartCoroutine(OnTrackingFoundYied(true));
            //isAction = true;
            //StopCoroutine("OnTrackingFoundInvoke");
            //Invoke("OnTrackingFoundInvoke", 0);

        }
        if (onFound != null)
            onFound.Invoke();
    }

    private bool isAction;
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
            try
            {
                //StopCoroutine("OnTrackingFoundYied");
                //StartCoroutine(OnTrackingFoundYied(false));

                isAction = false;
                StopCoroutine("OnTrackingFoundInvoke");
                Invoke("OnTrackingFoundInvoke", 0);
            }
            catch (UnityException e)
            {
                Debug.Log(e);
            }
            
        }
        if (onLost != null)
            onLost.Invoke();
    }

    //携程调用
    public IEnumerator OnTrackingFoundYied(bool type)
    {
        yield return null;
        ShowAndHide(type);
    }
    public void OnTrackingFoundInvoke()
    {
        ShowAndHide(isAction);
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
