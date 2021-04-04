using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCardManager : MonoBehaviour
{
    public GameCard[] gameCards;

    private static GameCardManager _instance;
    public static GameCardManager GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindWithTag("ImageManager").GetComponent<GameCardManager>();
            }
            return _instance;
        }
    }

    // Use this for initialization  
    void Start()
    {
        //通过屏幕坐标获取画布位置（参数作用看背包系统）  
        //Vector2 localPos;  
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(this.GetComponent<Canvas>().transform as RectTransform,Input.mousePosition,null,out localPos);  
    }

    // Update is called once per frame  
    void Update()
    {

    }

    /// <summary>  
    /// 卡片按钮点击事件  
    /// </summary>  
    /// <param name="gameCard"></param>  
    public void OnBtnClickGamecarReturn(GameCard gameCard)//鼠标点击事件，参数的属性会随游戏对象数据的改变而改变，其他的函数传参只是简单的赋值  
    {
        int a = (int)((gameCard.depth - 1) / 2);
        if (a == 0)
        {
            RollGamecard(gameCard);
        }
    }

    /// <summary>  
    ///遍历卡片旋转  
    /// </summary>  
    private void RollGamecard(GameCard gameCard)
    {
        gameCards = this.GetComponentsInChildren<GameCard>();//获取卡片组件  
        if (gameCard.isRightArea)
        {
            //逆时针旋转  
            for (int i = 0; i <= gameCards.Length - 1; i++)
            {
                GameCard item = gameCards[i];

                if (i == 0)
                {
                    //左边最后一张移动到右边最后一张  
                    item.UpdateCardAlphaAndSize(item.depth - 1);
                }
                else
                {
                    if (item.depth % 2 != 0)
                    {
                        //右边卡片逆时针旋转一个单位  
                        item.UpdateCardAlphaAndSize(item.depth - 2);
                    }
                    else
                    {
                        //左边卡片逆时针旋转一个单位  
                        item.UpdateCardAlphaAndSize(item.depth + 2);
                    }
                }
            }
        }
        else if (gameCard.isRightArea == false && gameCard.depth != 0)
        {
            //顺时针旋转  
            for (int i = 0; i <= gameCards.Length - 1; i++)
            {
                GameCard item = gameCards[i];
                if (i == 1)
                {
                    //最右边卡片移动到最左边  
                    item.UpdateCardAlphaAndSize(item.depth + 1);
                }
                else
                {
                    if (item.depth == 0)
                    {
                        item.UpdateCardAlphaAndSize(item.depth + 1);
                    }
                    else if (item.depth % 2 == 0)
                    {
                        //左边卡片  
                        item.UpdateCardAlphaAndSize(item.depth - 2);
                    }
                    else
                    {
                        item.UpdateCardAlphaAndSize(item.depth + 2);
                    }
                }
            }
        }
    }
}