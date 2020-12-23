using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsePotion : MonoBehaviour//, IPointerClickHandler
{
    private Inventory Inventory;
    private Slot slot;
    void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        slot = transform.GetComponentInParent<Slot>();
    }

    void Update()
    {
        
    }

    public void UsePotionHealth(int health)
    {
        Debug.Log("Use");
        SoundManager.soundManagerInstance.PlaySound("Potion_Use");
        Player.PlayerInstance.Health += health;
        Inventory.isFull[slot.slotId] = false;
        Destroy(gameObject);
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Debug.Log("Use");
    //    Player.PlayerInstance.health += 5;
    //    Destroy(gameObject);
    //}
}
