using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    //public Texture imageIcon;

    private Inv inv;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inv>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("name = " + gameObject.name);
            for (int numberFreeSlot = 0; numberFreeSlot < inventory.slots.Length; numberFreeSlot++)
            {
                if (inventory.isFull[numberFreeSlot] == false)
                {
                    //Add item to inventory
                    //Debug.Log("numberFree = " + numberFreeSlot);
                    inventory.isFull[numberFreeSlot] = true;
                    //inv.Rewdraw(imageIcon, numberFreeSlot);
                    SoundManager.soundManagerInstance.PlaySound("PlayerPickUp");
                    Instantiate(itemButton, inventory.slots[numberFreeSlot].transform, false);

                    Destroy(gameObject);

                    break;
                }
            }
        }
    }
}
