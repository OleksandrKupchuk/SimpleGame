using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager gameManagerInstance;
    private Text countCoinText;

    public static GameManager Instance
    {
        get
        {
            if(gameManagerInstance == null)
            {
                gameManagerInstance = FindObjectOfType<GameManager>();
            }

            else if(gameManagerInstance != FindObjectOfType<GameManager>())
            {
                Destroy(gameManagerInstance);
            }

            return gameManagerInstance;
        }
    }

    public int countCoin;

    void Start()
    {
        countCoinText = GameObject.FindGameObjectWithTag("PanelUI").transform.GetChild(3).transform.GetChild(1).GetComponent<Text>();
        countCoinText.text = "Coin : " + countCoin;
    }

    public void UpdateCoinText()
    {
        countCoinText.text = "Coin : " + countCoin;
    }

    public void InitializationCoin()
    {
        countCoin = 0;
    }
}
