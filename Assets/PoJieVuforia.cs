using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoJieVuforia : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(BeginPoJie());
        //Invoke("Play",1.3f);
	}
    void Play()
    {
        Transform target = null;
        while (true)
        {
            target = transform.Find("BackgroundPlane");
            if (target != null)
                break;
        }
        Material a = target.GetComponent<Renderer>().materials[0];
        a.SetTextureOffset("_MainTex", new Vector2(0, -0.17f));
        //target.localScale = target.localScale * 1.17786401f;
    }
    IEnumerator BeginPoJie()
    {
        yield return new WaitForSeconds(1.3f);
        Transform target = null;
        while (true)
        {
            target = transform.Find("BackgroundPlane");
            if (target != null)
                break;
        }
        //Material a = target.GetComponent<Renderer>().materials[0];
        //a.SetTextureOffset("_MainTex",new Vector2(0, 0.17f));
        target.localScale = target.localScale * 1.17786401f;
        
    }
}
