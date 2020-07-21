using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRotation : MonoBehaviour
{
    [Header("Parametrs")]
    [SerializeField] private List<string> collisionObject;
    [SerializeField] private GameObject debrisPrefab;

    private void Start()
    {

    }

    [System.Obsolete]
    void Update()
    {
        transform.RotateAroundLocal(Vector3.forward, 60);
        //transform.RotateAround(transform.localPosition, Vector3.back, Time.deltaTime * speedRotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collisionObject.Contains(collision.tag))
        {
            SpawnPartical();
        }
    }

    private void SpawnPartical()
    {
        GameObject debris = Instantiate(debrisPrefab);

        debris.transform.position = transform.position;
    }
}
