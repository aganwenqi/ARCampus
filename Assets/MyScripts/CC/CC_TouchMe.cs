using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class CC_TouchMe : MonoBehaviour {

    // Use this for initialization
    public UnityEvent down;
    public UnityEvent up;
    private RaycastHit ObjHit;
    private Ray CustomRay;
    void Start () {
		
	}

    public void ButtonDown()
    {
        if (down != null)
            down.Invoke();
    }
    public void ButtonUp()
    {
        if (up != null)
            up.Invoke();
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //从摄像机发出一条射线,到点击的坐标
            CustomRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //显示一条射线，只有在scene视图中才能看到
            Debug.DrawLine(CustomRay.origin, ObjHit.point, Color.red, 2);
            if (Physics.Raycast(CustomRay, out ObjHit, 100))
            {
                //Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began &&
                if ( ObjHit.transform == this.transform)
                {
                    ButtonDown();
                }
            }
        }
        //&& Input.GetTouch(0).phase == TouchPhase.Ended
        else if (Input.GetMouseButtonUp(0) )
        {
            if (ObjHit.transform == this.transform)
            {
                ButtonUp();
            }
        }
    }
}
