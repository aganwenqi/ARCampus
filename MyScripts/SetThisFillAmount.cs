using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetThisFillAmount : MonoBehaviour {

    // Use this for initialization
    private UISprite sprite;
    public void SetCurrentPercent()
    {
        if (UIProgressBar.current != null)
        {
            sprite.fillAmount = UIProgressBar.current.value;
        }
            
    }
    void Start () {
        sprite = GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
