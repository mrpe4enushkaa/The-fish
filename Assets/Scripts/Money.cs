using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private int countMoney;
    public string tagMoney;
    public int money = 0;
    public Text moneyText;
    public GameObject GameObjMoneyText;

    public string tagDoubling;
    public float time;
    [HideInInspector]
    public bool doubling;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        moneyText.text = money.ToString();
        TextFalse();
    }

    private void Update()
    {
        if (doubling)
        {
            countMoney = 2;
        }
        else if (!doubling)
        {
            countMoney = 1;
        }

        if(money < 0)
        {
            money = 0;
        }

        PlayerPrefs.SetInt("Money", money);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == tagMoney && !doubling)
        {
            GameObjMoneyText.SetActive(true);
            CancelInvoke("PlusMoney");
            Invoke("PlusMoney", 1);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == tagMoney && doubling)
        {
            GameObjMoneyText.SetActive(true);
            CancelInvoke("PlusDoubleMoney");
            Invoke("PlusDoubleMoney", 1);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == tagDoubling)
        {
            doubling = true;
            CancelInvoke("Double");
            Invoke("Double", time);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagMoney && !doubling)
        {
            GameObjMoneyText.SetActive(true);
            CancelInvoke("PlusMoney");
            Invoke("PlusMoney", 1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == tagMoney && doubling)
        {
            GameObjMoneyText.SetActive(true);
            CancelInvoke("PlusDoubleMoney");
            Invoke("PlusDoubleMoney", 1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == tagDoubling)
        {
            doubling = true;
            CancelInvoke("Double");
            Invoke("Double", time);
            Destroy(collision.gameObject);
        }
    }

    private void PlusMoney()
    {
        money += countMoney;
        moneyText.text = money.ToString();
        CancelInvoke("TextFalse");
        Invoke("TextFalse", 1);
        PlayerPrefs.SetInt("Money", money);
    }

    private void PlusDoubleMoney()
    {
        money += countMoney;
        moneyText.text = money.ToString();
        CancelInvoke("TextFalse");
        Invoke("TextFalse", 1);
        PlayerPrefs.SetInt("Money", money);
    }    

    private void TextFalse()
    {
        GameObjMoneyText.SetActive(false);
    }

    private void Double()
    {
        doubling = false;
    }
}
