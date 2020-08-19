using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    [HideInInspector] public GameObject[] slots;
    [SerializeField] private GameObject emptySlot;
    [SerializeField] private int disX;
    private GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");

        for (int i = 0; i < slots.Length; i++)
        {
            GameObject slot = Instantiate(emptySlot, new Vector3(disX, 0f, 0f), Quaternion.identity);
            Transform childCanvas = canvas.transform.GetChild(0);
            slot.transform.SetParent(childCanvas.transform, false);
            
            slots[i] = slot;

            disX += 60;
            //Debug.Log("yep");
        }
    }
}
