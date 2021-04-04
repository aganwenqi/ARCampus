using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnOFF : MonoBehaviour {

    // Use this for initialization
    public UITweener ui;
    private bool quit = true;
    public void Play()
    {
        ui.Play(quit);
        quit = !quit;
    }
	
}
