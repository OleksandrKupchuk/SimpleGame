using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinue : MonoBehaviour
{
    [SerializeField] private Player playerObject;
    [SerializeField] private GameObject buttonContinue;

    public void CheckNewGame()
    {
        if (playerObject.indexScene != 0)
        {
            buttonContinue.SetActive(true);
        }

        else
        {
            buttonContinue.SetActive(false);
        }
    }
}
