using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool GameIsPause = false;

    [Header("UI elements")]
    [SerializeField] private GameObject[] uiObject;
    public bool isEnableObject;
    private GameObject shopWindow;

    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        shopWindow = GameObject.FindGameObjectWithTag("Shop").transform.GetChild(0).gameObject;
        //Debug.Log(shopWindow.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isEnableObject)
            {
                if (!IsActiveShop())
                {
                    if (GameIsPause)
                    {
                        Resume();
                    }

                    else
                    {
                        Pause();
                    }
                }
            }
        }

        //Debug.Log(IsActiveShop());
    }

    public void Resume()
    {
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        for (int i = 0; i < uiObject.Length; i++)
        {
            uiObject[i].SetActive(true);
        }

        GameIsPause = false;
    }

    public void Pause()
    {
        for(int i = 0; i < uiObject.Length; i++)
        {
            uiObject[i].SetActive(false);
        }
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void EnableObject(int isEnable)
    {
        if(isEnable == 1)
        {
            isEnableObject = true;
        }

        else if (isEnable == 2)
        {
            isEnableObject = false;
        }
    }

    private bool IsActiveShop()
    {
        //if (shopWindow.gameObject != null)
        //{
        //    if (shopWindow.activeInHierarchy == false)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        if (shopWindow.activeInHierarchy == false)
        {
            return false;
        }

        return true;
        //else
        //{
        //    Debug.LogWarning("Object not found");
        //    return false;
        //}
    }
}
