using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    //标记卡片在父对象的优先级  
    public int depth;

    //确定是否在右边区域  
    public bool isRightArea = true;

    //卡片当前大小  
    public float currentSize = 1;

    //卡片目标大小  
    private float targetSize = 1;

    //卡片当前透明度  
    public float currentAlpha = 1;

    //卡片目标透明度  
    private float targetAlpha;

    //卡片当前位置  
    private Vector2 currentPos;

    //卡片目标位置  
    private Vector2 targetPos;

    //获取组件，控制其透明度  
    private CanvasGroup canvasGroup;

    public float theSpeed;
    private float speed;

    // Use this for initialization  
    void Start()
    {
        speed = theSpeed;
        //获取CanvasGroup组件，用于控制卡片的透明图  
        canvasGroup = this.GetComponent<CanvasGroup>();
        currentAlpha = canvasGroup.alpha;
        targetAlpha = currentAlpha;

        targetSize = currentSize;

        //改变ui锚点位置  
        currentPos = this.GetComponent<RectTransform>().anchoredPosition;
        targetPos = currentPos;

    }

    // Update is called once per frame  
    void Update()
    {
        //插值运算来控制其大小、透明度、位置  

        if (currentSize != targetSize)
        {

            currentSize = Mathf.Lerp(currentSize, targetSize, Time.deltaTime * 10.0f);
            if (Mathf.Abs(currentSize - targetSize) <= 0.01f)
            {
                currentSize = targetSize;
            }

            this.GetComponent<RectTransform>().localScale = new Vector3(currentSize, currentSize, 1);
        }

        if (currentAlpha != targetAlpha)
        {
            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * 50.0f);
            if (Mathf.Abs(currentAlpha - targetAlpha) <= 0.01f)
            {
                currentAlpha = targetAlpha;
            }

            canvasGroup.alpha = currentAlpha;
        }

        if (currentPos != targetPos)
        {
            if (Mathf.Abs(currentPos.x - targetPos.x) <= 240.0f && Mathf.Abs(currentPos.x - targetPos.x) != 0)
            {
                currentPos = Vector2.Lerp(currentPos, targetPos, Time.deltaTime * 10.0f);
            }
            else
            {
                //currentPos = targetPos;  
                currentPos = Vector2.Lerp(currentPos, targetPos, Time.deltaTime * 60);
            }
            if (Mathf.Abs(currentPos.x - targetPos.x) <= 0.01f)
            {
                currentPos = targetPos;
            }

            speed = theSpeed;
            this.GetComponent<RectTransform>().anchoredPosition = currentPos;
        }
    }

    /// <summary>  
    /// 更新透明图和大小  
    /// </summary>  
    /// <param name="depth"></param>  
    public void UpdateCardAlphaAndSize(int depth)
    {
        if (depth < 0)
        {
            depth = 0;
        }
        this.depth = depth;
        //this.GetComponent<RectTransform>().SetSiblingIndex(this.depth);//设置UI显示的优先级  
        this.GetComponent<Transform>().SetSiblingIndex(GameCardManager.GetInstance.gameCards.Length - this.depth - 1);



        switch (depth)
        {
            case 0:
                SetSize(1.0f);
                SetAlpha(1.0f);
                this.isRightArea = false;
                break;
            case 1:
                SetSize(0.9f);
                SetAlpha(0.8f);
                this.isRightArea = true;
                break;
            case 2:
                SetSize(0.9f);
                SetAlpha(0.8f);
                this.isRightArea = false;
                break;
            case 3:
                SetSize(0.8f);
                SetAlpha(0.8f);
                this.isRightArea = true;
                break;
            case 4:
                SetSize(0.8f);
                SetAlpha(0.8f);
                this.isRightArea = false;
                break;
            default:
                break;
        }

        //刷新Gamecard位置  
        SetRectTransform();
    }


    private void SetAlpha(float targetAlpha)
    {
        this.targetAlpha = targetAlpha;
    }

    private void SetSize(float targetSize)
    {
        this.targetSize = targetSize;
    }

    /// <summary>  
    /// 更新位置  
    /// </summary>  
    private void SetRectTransform()
    {
        switch (this.depth)
        {
            case 0:
                //this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);  
                targetPos = new Vector2(0, 0);
                break;
            case 1:
                //this.GetComponent<RectTransform>().anchoredPosition = new Vector2(120, 0);  
                targetPos = new Vector2(120, 0);
                break;
            case 2:
                //this.GetComponent<RectTransform>().anchoredPosition = new Vector2(-120, 0);  
                targetPos = new Vector2(-120, 0);
                break;
            case 3:
                //this.GetComponent<RectTransform>().anchoredPosition = new Vector2(240, 0);  
                targetPos = new Vector2(220, 0);
                break;
            case 4:
                //this.GetComponent<RectTransform>().anchoredPosition = new Vector2(-240, 0);  
                targetPos = new Vector2(-220, 0);
                break;
            default:
                break;
        }
    }
}