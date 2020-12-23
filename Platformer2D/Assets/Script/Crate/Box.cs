using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] Rigidbody2D boxRigidbody2D;
    [SerializeField] BoxCollider2D boxBoxCollider2D;
    [SerializeField] float heightBoxCast;
    [SerializeField] LayerMask layerMask;
    [SerializeField] public bool isGround;
    public int massBox;
    private Vector2 startPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            transform.position = startPosition;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("PressPlatform"))
    //    {
    //        massBox = (int)boxRigidbody2D.mass;
    //        collision.gameObject.GetComponent<PressOnPlatform>().massItems -= massBox;
    //    }
    //}

    private void Start()
    {
        massBox = (int)boxRigidbody2D.mass;
        startPosition = new Vector2(transform.position.x, transform.position.y);
    }

    //private void Update()
    //{
    //    RaycastHit2D boxOnGround = Physics2D.BoxCastAll(boxBoxCollider2D.bounds.center, boxBoxCollider2D.bounds.size, 0f, Vector2.down, heightBoxCast, layerMask);

    //    isGround = boxOnGround;

    //    Color colorLine;
    //    if (boxOnGround.collider != null)
    //    {
    //        colorLine = Color.blue;
    //    }

    //    else
    //    {
    //        colorLine = Color.red;
    //    }

    //    Debug.DrawRay(boxBoxCollider2D.bounds.center + new Vector3(boxBoxCollider2D.bounds.extents.x, 0), Vector2.down * (boxBoxCollider2D.bounds.extents.y + heightBoxCast), colorLine);
    //    //Debug.DrawRay(playerBoxCollider2d.bounds.center + new Vector3(playerBoxCollider2d.bounds.extents.x, 0), Vector2.down * (playerBoxCollider2d.bounds.extents.y + distacneBoxCast), colorLine);
    //    Debug.DrawRay(boxBoxCollider2D.bounds.center - new Vector3(boxBoxCollider2D.bounds.extents.x, 0), Vector2.down * (boxBoxCollider2D.bounds.extents.y + heightBoxCast), colorLine);
    //    Debug.DrawRay(boxBoxCollider2D.bounds.center - new Vector3(boxBoxCollider2D.bounds.extents.x, boxBoxCollider2D.bounds.extents.y + heightBoxCast), Vector2.right * (boxBoxCollider2D.bounds.size.x), colorLine);

    //}
}
