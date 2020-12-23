using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject destructable;
    [SerializeField] private GameObject potionHealth;

    private bool isShaking = false;
    [SerializeField] private float shakeAmount;
    private Vector2 startPosition;
    void Start()
    {
        
    }

    void Update()
    {
        if (isShaking)
        {
            transform.position = startPosition + Random.insideUnitCircle * shakeAmount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerSword"))
        {
            startPosition = transform.position;

            health--;

            if(health <= 0)
            {
                Explosion();
            }

            else
            {
                isShaking = true;
                Invoke("ResetShake", 0.5f);
            }
        }
    }

    private void Explosion()
    {
        int chancePotion = Random.Range(0, 10);

        Instantiate(destructable, transform.position, Quaternion.identity);
        if(chancePotion <= 5)
        {
            Instantiate(potionHealth, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void ResetShake()
    {
        isShaking = false;
        transform.position = startPosition;
    }
}
