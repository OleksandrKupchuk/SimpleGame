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
        Vector2 playerPositions;

        if (Player.Instance.facingRight)
        {
            playerPositions = new Vector2(player.position.x + 1f, player.position.y - 0.7f);
            Instantiate(item, playerPositions, Quaternion.identity);
        }
        if (!Player.Instance.facingRight)
        {
            playerPositions = new Vector2(player.position.x - 1f, player.position.y - 0.7f);
            Instantiate(item, playerPositions, Quaternion.identity);
        }
    }
}
