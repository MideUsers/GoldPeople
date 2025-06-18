using UnityEngine;

public class OtherFish : MonoBehaviour
{
    public bool isSwim;
    void ChangeSwim(bool isbool)
    {
        if (isbool)
        {
            GetComponent<RectTransform>().Rotate(0, 0, 0);//向左
        }
        else
        {
            GetComponent<RectTransform>().Rotate(0, 180, 0);//向右
        }
    }
    void Start()
    {
        GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
        if (Random.Range(0, 2) == 1)
        {
            isSwim = false;
            ChangeSwim(isSwim);
        }
        else
        {
            isSwim = true;
            ChangeSwim(isSwim);
        }
    }
    void Update()
    {
        if (GetComponent<RectTransform>().anchoredPosition.x < -653 && !isSwim)
        {
            if (GetComponent<RectTransform>().anchoredPosition.x < -653 && !isSwim)
            {
                isSwim = true;
                ChangeSwim(isSwim);
            }
            if (isSwim)
            {
                isSwim = false;
                ChangeSwim(isSwim);
            }
            else
            {
                isSwim = true;
                ChangeSwim(isSwim);
            }
        }
        if (isSwim == false)
        {
            GetComponent<RectTransform>().anchoredPosition += new Vector2(0.2f, 0);
        }
        else
        {
            GetComponent<RectTransform>().anchoredPosition -= new Vector2(0.2f, 0);
        }
    }

}
