using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager gameManagerInstance;

    //[SerializeField] GameObject gameObjectCanvas;
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

    [SerializeField] GameObject coinPrefab;

    public GameObject Coin
    {
        get
        {
            return coinPrefab;
        }
    }

    //public int CountCoin { get => countCoin; set => countCoin = value; }

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
    // Start is called before the first frame update
    void Start()
    {
        countCoinText = GameObject.Find("TextCoin").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("coin = " + CountCoin);
        //Debug.Log("coin = " + countCoin);
    }
}
