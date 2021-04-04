using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Delay Show And Hidh;
public class CC_OpenFieldController : MonoBehaviour {

    public GameObject[] targets;
    private bool sAndh;
    private void Awake()
    {
        
    }
    public void SetActiveTrue(float delayTime)
    {
        if (targets.Length > 0)
        {
            Invoke("SetActiveDelay", delayTime);
            sAndh = true;
        }     
    }
    public void SetActiveFalse(float delayTime)
    {
        if (targets.Length > 0)
        {
            Invoke("SetActiveDelay", delayTime);
            sAndh = false;
        }
    }
    void SetActiveDelay()
    {
        this.StopAllCoroutines();
        foreach (var i in targets)
            i.SetActive(sAndh);
    }
}
