using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLiZiController : MonoBehaviour {

    // Use this for initialization
    public GameObject lizi;
    public Vector3[] pos;
	void Start () {
        if (lizi != null)
            lizi.SetActive(false);

    }
    public void Show(int level)
    {
        lizi.transform.localPosition = new Vector3(
            pos[level].x,
            pos[level].y,
            pos[level].z
            );
        lizi.SetActive(true);
    }
    public void Hide()
    {
        lizi.SetActive(false);
    }
}
