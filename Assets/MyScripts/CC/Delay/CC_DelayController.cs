using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_DelayController : MonoBehaviour {

    // Use this for initialization
    public CC_DelayShowAndHide[] showAndHide;


   
    void Start () {
        var ar = this.GetComponent<CC_DefaultTrackableEventHandler>();
        ar.onFound.AddListener(OnFound);
        ar.onLost.AddListener(OnLost);
    }
    private void OnFound()//必须有挂载CC_DefaultTrackableEventHandle
    {
        foreach (var ar in showAndHide)
        {
            StartCoroutine(OnFoundDelay(ar));
        }
    }
    private IEnumerator OnFoundDelay(CC_DelayShowAndHide target)
    {
        yield return new WaitForSeconds(target.startTime);
        target.target.SetActive(true);
        CC_DelayTarget dt = target.target.GetComponent<CC_DelayTarget>();
        if (dt == null)
            target.target.AddComponent<CC_DelayTarget>().Play(target.endTime);
        else
            dt.Play(target.endTime);
    }
    private void OnLost()
    {
        foreach (var ar in showAndHide)
        {
            
            ar.target.SetActive(false);
        }
        StopAllCoroutines();
    }
}
