using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager gameManagerInstance;
    private Text countCoinText;

    public static GameManager GameManagerInstance
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

    public int CountCoin
    {
        get
        {
            return countCoin;
        }

        set
        {
            countCoin = value;
            countCoinText.text = "Coin : " + countCoin;
        }
    }

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);

    //    if (gameManagerInstance == null)
    //    {
    //        gameManagerInstance = FindObjectOfType<GameManager>();
    //    }

    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        countCoinText = GameObject.FindGameObjectWithTag("PanelUI").transform.GetChild(3).transform.GetChild(1).GetComponent<Text>();
        countCoinText.text = "Coin : " + countCoin;
        //SetCoin();
    }

    void Update()
    {
        
    }

    public void InitializationCoin()
    {
        countCoin = 0;
    }
}
