using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidEscape : MonoBehaviour {

    // Use this for initialization
    public TweenRotation[] uiRotation;
    private Gyroscope go;
	void Start () {
        go = Input.gyro;
        go.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        return;
        foreach (var i in uiRotation)
        {
            //旋转
            if (
                go.attitude.y <= 0.1f && go.attitude.y >= -0.1f ||
                go.attitude.y >= (-0.8f) && go.attitude.y <= (-0.6f) ||
                go.attitude.y >= (-0.2f) && go.attitude.y <= 0 ||
                go.attitude.y >= 0.6f && go.attitude.y <= 0.8f
                )
            {
                i.transform.rotation = new Quaternion(i.transform.rotation.x, i.transform.rotation.y, -go.attitude.z, i.transform.rotation.w);
            }
            
        }
        if (go.attitude == new Quaternion(go.attitude.x, go.attitude.y,1, go.attitude.w))
        {
            foreach (var i in uiRotation)
                i.PlayForward();
        }
	}
}
