using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Vector2 mousePosition;
    private RaycastHit2D raycastHit;

    public bool IsElemtntUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //IsElemtntUI = CheckElementUI();
        CheckElementUI();

        Debug.Log("IsElemtntUI = " + IsElemtntUI);
    }

    //private bool CheckElementUI()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        raycastHit = Physics2D.Raycast(mousePosition, Vector2.zero);

    //        //Debug.Log("raycast = " + raycastHit.collider.name);
    //        if (raycastHit.collider.CompareTag("Inventory"))
    //        {
    //            return true;
    //        }
    //    }

    //    return false;
    //}

    private void CheckElementUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            raycastHit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //Debug.Log("raycast = " + raycastHit.collider.name);
            if (raycastHit.collider.CompareTag("Inventory"))
            {
                IsElemtntUI = true;
            }
        }

        else
        {
            IsElemtntUI = false;
        }
    }
}
