using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour {

    // Use this for initialization
    private Vector3 ve;
    public float time;
    private void Awake()
    {
        ve = transform.localScale;
    }
    private void OnEnable()
    {
        this.transform.localScale = Vector3.zero;
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(time);
        this.transform.localScale = ve;
    }
    private void OnDisable()
    {
        this.StopAllCoroutines();
        this.transform.localScale = Vector3.zero;
    }
}
