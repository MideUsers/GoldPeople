using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyFish : MonoBehaviour,IDragHandler
{
    
    public Transform CreatFishPoint;
    public GameObject gameOver;
    public GameObject gameWin;
    int level = 0;
    public Text LevelText;
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("我是余");
        transform.position = Input.mousePosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {
            if (GetComponent<RectTransform>().sizeDelta.x > collision.GetComponent<BoxCollider2D>().size.x)
            {
                GetComponent<RectTransform>().sizeDelta += new Vector2(10, 10);
                GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;

                GameObject newFishPrefabs = collision.gameObject;
                GameObject newFish = Instantiate(newFishPrefabs, CreatFishPoint);
                newFish.transform.localPosition = new Vector2(-800, collision.transform.position.y - 400);

                newFish.GetComponent<OtherFish>().isSwim = false;
                level += 1;
                LevelText.text = "等级：" + level;
                Destroy(collision.gameObject);

                if (level >= 15)
                {
                    gameWin.SetActive(true);
                }
            }
            else
            {
                gameOver.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
    }

}
