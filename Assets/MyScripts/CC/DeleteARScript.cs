using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class DeleteARScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.GetComponent<VuforiaBehaviour>());
        Destroy(this.GetComponent<VideoBackgroundBehaviour>());
    }
}
