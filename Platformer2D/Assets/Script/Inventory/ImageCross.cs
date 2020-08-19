using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageCross : MonoBehaviour, IPointerClickHandler
{
    private Inventory inventory;
    [SerializeField] private GameObject canvas;
    [SerializeField] private int numberSlot;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Transform childCanvas = canvas.transform.GetChild(0);
        Slot drop = childCanvas.transform.GetChild(numberSlot).GetComponent<Slot>();
        drop.DropItems();
        inventory.isFull[numberSlot] = false;
        Debug.Log("click = " + gameObject.name);
    }
}
