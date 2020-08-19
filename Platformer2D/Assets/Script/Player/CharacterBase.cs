using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public int damage;
    public int speed;
    public bool facingRight;

    public virtual void Start()
    {
        facingRight = true;
    }
}
