using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inv : MonoBehaviour
{
    #region Inventory
    //public Items item;
    //public int[] items;

    //private void OnGUI()
    //{
    //    for(int countRow = 0; countRow < 5; countRow++)
    //    {
    //        for (int countColumn = 0; countColumn < 5; countColumn++)
    //        {
    //            GUI.Button(new Rect(countRow * 50, countColumn * 50, 40, 40), item.Images[items[countColumn * 5 + countRow]]);
    //            //Debug.Log("items = " + (countColumn * 5 + countRow));
    //        }
    //    }
    //}
    #endregion

    public int width;
    public int height;
    public Transform panel;
    [SerializeField] GameObject slot;
    GameObject spawnSlot;

    private void Start()
    {
        for(int i = 0; i < width*height; i++)
        {
            //spawnSlot = Instantiate((GameObject)Resources.Load("ButtonSlot"));
            spawnSlot = Instantiate(slot);
            spawnSlot.transform.SetParent(panel);
            //spawnSlot.GetComponent<InvButton>().myInv = this;
            spawnSlot.GetComponent<InvButton>().buttonId = i;
            Debug.Log("id = " + spawnSlot.GetComponent<InvButton>().buttonId);
        }
    }

    public void SelectId(int id)
    {
        print(id);
    }

    public void Rewdraw(Texture icon, int numberSlot)
    {
        for (int i = 0; i < width * height; i++)
        {
            panel.GetChild(numberSlot).GetChild(0).GetComponent<RawImage>().texture = icon;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < width * height; i++)
        {
            //panel.GetChild(i).GetChild(0).GetComponent<RawImage>().texture = collision.gameObject.GetComponent<PickUp>().imageIcon;
        }
        //collision.gameObject.GetComponent<Items>().Images;
    }
}
