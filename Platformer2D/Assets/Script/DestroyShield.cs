using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Live");

        if (Player.PlayerInstance.shieldDie)
        {
            Destroy(gameObject);
            //Debug.Log("Die");
        }
    }
}
