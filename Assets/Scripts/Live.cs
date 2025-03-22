using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Live : MonoBehaviour
{
    public float lives = 1;
    public string tagDeath;
    public GameObject deathPanel;
    public Button buttonMenu;

    public GameObject buyLifePanel;
    public int price = 10;
    float t;
    public float time;
    public int desiredDistance;
    [HideInInspector]
    public bool purchased;
    public Button buyLifeButton;
    public Button notBuyLifeButton;
    bool buttonBuyDown;
    bool buttonNotBuyDown;
    public Text noMoney;
    public Text priceText;
    public Text moneyText;

    private void Start()
    {
        buyLifePanel.SetActive(false);
        purchased = false;
        lives = 1;
        buttonBuyDown = false;
        buttonNotBuyDown = false;
        noMoney.text = "";
        deathPanel.SetActive(false);
        buttonMenu.onClick.AddListener(GameOver);
        gameObject.SetActive(true);
        priceText.text = price.ToString();
    }

    private void Update()
    {
        buyLifeButton.onClick.AddListener(ExtraLife);
        notBuyLifeButton.onClick.AddListener(Death);
        moneyText.text = "Money: " + PlayerPrefs.GetInt("Money");
        priceText.text = price.ToString();

        if (lives == 0 && desiredDistance < GetComponent<Score>().score && purchased == false)
        {
            t = t + Time.deltaTime;
            buyLifePanel.SetActive(true);
            gameObject.SetActive(true);

            if (t >= time)
            {
                buyLifePanel.SetActive(false);
                if (GetComponent<Score>().score > GetComponent<Score>().bestScore)
                {
                    GetComponent<Score>().bestScore = GetComponent<Score>().score;
                }
                PlayerPrefs.SetInt("BestScore", GetComponent<Score>().bestScore);
                GetComponent<Player>().ObjButton.SetActive(false);
                GetComponent<Score>().gameOverText.text = "Score:" + GetComponent<Score>().score.ToString() + "m" + "\nBest score:" + GetComponent<Score>().bestScore.ToString() + "m";
                deathPanel.SetActive(true);
            }
            if (buttonBuyDown == true && buttonNotBuyDown == false)
            {
                buyLifePanel.SetActive(false);
                lives = 1;
                GetComponent<Money>().money -= price;
                purchased = true;
            }
            else if (buttonBuyDown == false && buttonNotBuyDown == true)
            {
                buyLifePanel.SetActive(false);
                if (GetComponent<Score>().score > GetComponent<Score>().bestScore)
                {
                    GetComponent<Score>().bestScore = GetComponent<Score>().score;
                }
                PlayerPrefs.SetInt("BestScore", GetComponent<Score>().bestScore);
                GetComponent<Score>().gameOverText.text = "Score:" + GetComponent<Score>().score.ToString() + "m" + "\nBest score:" + GetComponent<Score>().bestScore.ToString() + "m";
                deathPanel.SetActive(true);
            }
        }
        if(lives == 0 && desiredDistance >= GetComponent<Score>().score && purchased == false || lives == 0 && desiredDistance <= GetComponent<Score>().score && purchased == true)
        {
            buyLifePanel.SetActive(false);
            if (GetComponent<Score>().score > GetComponent<Score>().bestScore)
            {
                GetComponent<Score>().bestScore = GetComponent<Score>().score;
            }
            PlayerPrefs.SetInt("BestScore", GetComponent<Score>().bestScore);
            GetComponent<Player>().ObjButton.SetActive(false);
            GetComponent<Score>().gameOverText.text = "Score:" + GetComponent<Score>().score.ToString() + "m" + "\nBest score:" + GetComponent<Score>().bestScore.ToString() + "m";
            deathPanel.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == tagDeath)
        {
            lives = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagDeath)
        {
            lives = 0;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    void ExtraLife()
    {
        if(GetComponent<Money>().money >= price)
        {
            buttonBuyDown = true;
        }
        else if(GetComponent<Money>().money < price)
        {
            buttonBuyDown = false;
            noMoney.text = "No money";
        }
    }

    void Death()
    {
        buttonNotBuyDown = true;
    }
}
