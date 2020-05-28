using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    [SerializeField] private GameObject itemButton;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Potion"))
    //    {
    //        for (int numberFreeSlot = 0; numberFreeSlot < slots.Length; numberFreeSlot++)
    //        {
    //            if (isFull[numberFreeSlot] == false)
    //            {
    //                //Add item to inventory
    //                //Debug.Log("numberFree = " + numberFreeSlot);
    //                isFull[numberFreeSlot] = true;
    //                //inv.Rewdraw(imageIcon, numberFreeSlot);
    //                SoundManager.soundManagerInstance.PlaySound("PlayerPickUp");
    //                Instantiate(itemButton, slots[numberFreeSlot].transform, false);
    //                Destroy(collision.gameObject);

    //                break;
    //            }
    //        }
    //    }
    //}
}
