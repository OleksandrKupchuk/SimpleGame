using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("Parametrs")]
    [SerializeField] private Collider2D circleCollider;
    [SerializeField] private List<string> collisionObject;
    [SerializeField] private GameObject smokePartical;
    [SerializeField] private GameObject debrisPrefab;
    [SerializeField] private GameObject particalExplosion;
    [SerializeField] private Rigidbody2D meteorRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private GameObject meteor;
    [SerializeField] private GameObject explosion;
    [SerializeField] private AudioSource audio;
    private float positionX;
    private float positionY;
    private GameObject player;
    private GameObject cameraObject;
    private Animator cameraAnimator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        cameraAnimator = cameraObject.GetComponent<Animator>();

        positionX = Random.Range(player.GetComponent<PlayerCollision>().axisMinX, player.GetComponent<PlayerCollision>().axisMaxX);
        positionY = player.GetComponent<PlayerCollision>().axisY;

        //Debug.Log("metMin = " + player.GetComponent<PlayerCollision>().axisMinX);
        //Debug.Log("metMax = " + player.GetComponent<PlayerCollision>().axisMaxX);

        //Debug.Log("startX = " + positionX);
        //Debug.Log("startY = " + positionY);

        var angle = Mathf.Atan2(transform.position.y - positionY, transform.position.x - positionX) * Mathf.Rad2Deg;
        smokePartical.transform.Rotate(0f, 0f, angle);
    }

    private void FixedUpdate()
    {
        PathMeteor(positionX, positionY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collisionObject.Contains(collision.tag))
        {
            SpawnPartical();
        }
    }

    public void PathMeteor(float posX, float posY)
    {
        Vector2 newPos = Vector2.MoveTowards(meteorRigidbody.position, new Vector2(posX, posY), speed * Time.deltaTime);
        meteorRigidbody.MovePosition(newPos);
        //Debug.Log("UpdateX = " + posX);
        //Debug.Log("UpdateY = " + positionY);
    }

    private void SpawnPartical()
    {
        circleCollider.enabled = false;

        Instantiate(debrisPrefab, transform.position, Quaternion.identity);

        Instantiate(explosion, transform.position, Quaternion.identity);

        ShakeCamera();

        audio.Play();

        Instantiate(particalExplosion, transform.position, Quaternion.identity);

        Destroy(meteor);

        var main = smokePartical.GetComponent<ParticleSystem>().main;
        main.loop = false;

        Destroy(gameObject, 1.5f);
    }

    private void ShakeCamera()
    {
        cameraAnimator.SetTrigger("Shake");
        //touchGrround = false;
    }
}
