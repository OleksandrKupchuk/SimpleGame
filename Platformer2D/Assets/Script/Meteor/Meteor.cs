using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("Parametrs")]
    //[SerializeField] private float speedMinRotation;
    //[SerializeField] private float speedMaxRotation;
    [SerializeField] private List<string> collisionObject;
    [SerializeField] private GameObject smokePartical;
    [SerializeField] private GameObject debrisPrefab;
    [SerializeField] private Rigidbody2D meteorRigidbody;
    [SerializeField] private float speed;
    [SerializeField] GameObject meteor;
    [SerializeField] GameObject explosion;
    private float target;
    private GameObject player;
    private Transform playerTransform;
    private GameObject partical;
    //private float speedRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        //target = Random.Range(player.transform.position.x - 0.5f, player.transform.position.x + 0.5f);
        var angle = Mathf.Atan2(transform.position.y - playerTransform.position.y, transform.position.x - playerTransform.position.x) * Mathf.Rad2Deg;
        //partical = Instantiate(smokePartical, transform.position, Quaternion.Euler(0f, 0f, angle));
        smokePartical.transform.Rotate(0f, 0f, angle);
    }

    [System.Obsolete]
    void Update()
    {
        //transform.RotateAroundLocal(Vector3.forward, angleRotation);
        //transform.RotateAround(meteor.transform.localPosition, Vector3.back, Time.deltaTime * speedRotation);
        //partical.transform.position = transform.position;

        //Vector2 newPos = Vector2.MoveTowards(meteorRigidbody.position, point.position, speed * Time.fixedDeltaTime);
        //meteorRigidbody.MovePosition(newPos);
        PathMeteor();

        Debug.Log("x = " + player.GetComponent<PlayerCollision>().targetX);
        Debug.Log("y = " + player.GetComponent<PlayerCollision>().axisY);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collisionObject.Contains(collision.tag))
        {
            SpawnPartical();
        }
    }

    public void PathMeteor()
    {
        Vector2 newPos = Vector2.MoveTowards(meteorRigidbody.position, new Vector2(player.GetComponent<PlayerCollision>().targetX, player.GetComponent<PlayerCollision>().axisY), speed * Time.fixedDeltaTime);
        meteorRigidbody.MovePosition(newPos);
    }

    private void SpawnPartical()
    {

       Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(meteor);
        //Destroy(smokePartical, 2.1f);
        //Destroy(gameObject, 0.6f);
    }
}
