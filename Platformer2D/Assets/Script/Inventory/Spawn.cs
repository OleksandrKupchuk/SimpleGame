using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPositions = new Vector2(player.position.x + 1.5f, player.position.y + 0.2f);
        Instantiate(item, playerPositions, Quaternion.identity);
    }
}
