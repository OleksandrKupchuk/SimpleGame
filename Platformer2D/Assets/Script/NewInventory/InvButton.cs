using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvButton : MonoBehaviour
{
    ///public Inv myInv;
    public int buttonId;
    public RectTransform rectTransform;

    private void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //rectTransform.sizeDelta = new Vector2(60, 60);
         
    }

    public void Press()
    {
        //myInv.SelectId(buttonId);
    }
}
