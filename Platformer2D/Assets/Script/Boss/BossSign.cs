using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSign : MonoBehaviour
{
    [SerializeField] Boss boss;
    public float distanceX;
    public float distanceY;
    private RaycastHit2D hitInfoX;
    public RaycastHit2D hitInfoY;
    private GameObject player;
    Vector3 possition;
    [SerializeField] private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        SightY();

        possition = new Vector3(transform.position.x, transform.position.y + 1.4f);

        if (boss.facingRight)
        {
            hitInfoX = Physics2D.Raycast(possition, Vector2.right, distanceX);
            if (hitInfoX.collider != null)
            {
                Debug.DrawLine(possition, hitInfoX.point, Color.red);
                if (hitInfoX.collider.CompareTag("Player"))
                {
                    boss.Target = player;
                }
            }
            else
            {
                Debug.DrawLine(possition, possition + Vector3.right * distanceX, Color.green);
                boss.Target = null;
            }
        }
        else if (!boss.facingRight)
        {
            hitInfoX = Physics2D.Raycast(possition, Vector2.left, distanceX);

            if (hitInfoX.collider != null)
            {
                Debug.DrawLine(possition, hitInfoX.point, Color.red);
                if (hitInfoX.collider.CompareTag("Player"))
                {
                    boss.Target = player;
                }
            }
            else
            {
                Debug.DrawLine(possition, possition + Vector3.left * distanceX, Color.green);
                boss.Target = null;
            }
        }
    }

    private void SightY()
    {
        //hitInfoY = Physics2D.Raycast(transform.position, Vector2.up, distanceY);
        hitInfoY = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.up, distanceY);

        if (hitInfoY.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfoY.point, Color.red);
            if (hitInfoY.collider.CompareTag("PlatformGround"))
            {
                boss.CanJump = false;
            }
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.up * distanceY, Color.green);
            boss.CanJump = true;
        }
    }
}
