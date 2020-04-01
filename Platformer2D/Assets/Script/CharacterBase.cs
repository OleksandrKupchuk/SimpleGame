using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public int damage;
    [SerializeField] public int speed;
    public bool facingRight;

    //public int Health { get => health; private set => health = value; }

    // Start is called before the first frame update
    public virtual void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
