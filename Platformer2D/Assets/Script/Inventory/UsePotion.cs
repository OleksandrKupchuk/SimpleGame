using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsePotion : MonoBehaviour//, IPointerClickHandler
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UsePotionHealth(int health)
    {
        Debug.Log("Use");
        SoundManager.soundManagerInstance.PlaySound("Potion_Use");
        Player.PlayerInstance.health += health;
        Destroy(gameObject);
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Debug.Log("Use");
    //    Player.PlayerInstance.health += 5;
    //    Destroy(gameObject);
    //}
}
