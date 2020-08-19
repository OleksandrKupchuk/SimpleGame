using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyBase : CharacterBase
{
    [SerializeField] private DestroyEnemyObject parentObject;

    [SerializeField] private GameObject combatText;
    [SerializeField] private float combatTextPosition;

    protected Canvas canvasHealth;
    [SerializeField] Image imageHealthBar;
    [SerializeField] GameObject gameObjectHealthBar;
    private float fillAmountHealth;

    [SerializeField] GameObject coinPrefab;

    public IStateEnemy currentState;

    protected float timeAttack;
    [SerializeField] protected float delayAttack;

    public bool CanAttack { get; set; }
    public bool firstAttack = false;

    protected float dirPlayer;
    public GameObject EnemyTarget { get; set; }

    [SerializeField] protected float enemyRangeAttack;
    [SerializeField] int experienceForTheEnemy;

    public float distance;
    RaycastHit2D hitInfo;
    private GameObject playerObject;
    [SerializeField] private LayerMask layerMask;


    public bool EnemyRangeAttack
    {
        get
        {
            if (EnemyTarget != null)
            {
                if (Vector2.Distance(EnemyTarget.transform.position, transform.position) <= enemyRangeAttack)
                {
                    return true;
                }
            }

            else
            {
                return false;
            }

            return false;
        }
    }

    public bool EnemyOutsideEdge
    {
        get
        {
            if(transform.position.x > rightEdge.position.x || transform.position.x < leftEdge.position.x) //<= >=
            {
                return true;
            }

            return false;
        }
    }

    //edges for enemy
    [SerializeField] protected Transform leftEdge;
    [SerializeField] protected Transform rightEdge;

    public bool EnemyDie 
    {
        get
        {
            if(health <= 0)
            {
                return true;
            }

            return false;
        }
    }
    [SerializeField] EdgeCollider2D enemySword;

    [SerializeField] private Rigidbody2D enemyRigidbody;
    public Rigidbody2D EnemyRigidbody { get => enemyRigidbody; set => enemyRigidbody = value; }

    public Animator enemyAnimator;

    public bool EnemyAttack { get; set; }

    public bool EnemyHit { get; set; }
    protected float directionEnemy;

    public override void Start()
    {
        base.Start();

        Physics2D.queriesStartInColliders = false;
        enemyAnimator = GetComponent<Animator>();

        canvasHealth = transform.GetComponentInChildren<Canvas>();

        imageHealthBar.fillAmount = CurrentFillAmountHealth();

        playerObject = GameObject.FindGameObjectWithTag("Player");
        Physics2D.queriesStartInColliders = false;
    }

    public virtual void Update()
    {
        //CheckPlayer();
    }

    protected float CurrentFillAmountHealth()
    {
        return fillAmountHealth = health / maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!EnemyDie)
        {
            if (!canvasHealth.isActiveAndEnabled)
            {
                canvasHealth.enabled = true;
            }

            enemyAnimator.SetTrigger("animatorEnemyHit");
            health -= damage;
            GameObject textDamage = Instantiate(combatText, new Vector3(transform.position.x, transform.position.y + combatTextPosition), Quaternion.identity);
            textDamage.transform.GetChild(0).GetComponent<TextMeshPro>().text = damage.ToString();

            imageHealthBar.fillAmount = CurrentFillAmountHealth();

            if (EnemyDie)
            {
                gameObjectHealthBar.SetActive(false);
                enemySword.enabled = false;
                Die();
            }
        }
    }

    public void Die()
    {
        gameObject.layer = 23;
        enemyAnimator.SetTrigger("animatorEnemyDie");
        Player.PlayerInstance.AddIndicatorForPlayer(experienceForTheEnemy);

        Debug.Log("die");
        SpawnItems();
        Destroy(gameObject, 1.5f);
        parentObject.DestroyObject();
    }

    public void SpawnItems()
    {
        Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
    }

    public void EnemySwordEnabled()
    {
        enemySword.enabled = true;
    }

    public void EnemySwordDisabled()
    {
        enemySword.enabled = false;
    }

    public void Flip()
    {
        //Debug.Log("Flip");
        facingRight = !facingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        if (facingRight || !facingRight)
        {
            canvasHealth.transform.localScale = new Vector3(canvasHealth.transform.localScale.x * -1, canvasHealth.transform.localScale.y, canvasHealth.transform.localScale.z);
        }
    }

    public void Walk()
    {
        if (!EnemyAttack && !EnemyDie && !EnemyHit)
        {
            if ((ChangeSide().x > 0 && transform.position.x < rightEdge.position.x) || (ChangeSide().x < 0 && transform.position.x > leftEdge.position.x))
            {
                enemyAnimator.SetFloat("animatorEnemyRun", 1);
                transform.Translate(ChangeSide() * speed * Time.deltaTime);
            }
        }
    }

    //public void Walk()
    //{
    //    if ((ChangeSide().x > 0 && transform.position.x < rightEdge.position.x) || (ChangeSide().x < 0 && transform.position.x > leftEdge.position.x))
    //    {
    //            enemyAnimator.SetFloat("animatorEnemyRun", 1);
    //            transform.Translate(ChangeSide() * speed * Time.deltaTime);
    //    }
    //}

    public Vector3 ChangeSide()
    {
        if (facingRight)
        {
            return Vector3.right;
        }

        return Vector3.left;
    }

    public void ChangeDirection()
    {
        if (transform.position.x >= rightEdge.position.x || transform.position.x <= leftEdge.position.x)
        {
            Flip();
        }
    }

    //public void EnemyLookTarget()
    //{
    //    if (!EnemyDie && EnemyTarget != null)
    //    {
    //        if (EnemyTarget != null && EnemyTarget.transform.position.x >= leftEdge.position.x || EnemyTarget.transform.position.x <= rightEdge.position.x)
    //        {
    //            directionEnemy = EnemyTarget.transform.position.x - transform.position.x;
    //            if (directionEnemy < 0 && facingRight || directionEnemy > 0 && !facingRight)
    //            {
    //                Flip();
    //            }
    //        }
    //    }
    //}

    public void EnemyLookTarget()
    {
        if (!EnemyDie && EnemyTarget != null)
        {
            directionEnemy = EnemyTarget.transform.position.x - transform.position.x;
            if (directionEnemy < 0 && facingRight || directionEnemy > 0 && !facingRight)
            {
                Flip();
            }
        }
    }

    //public virtual void Attack()
    //{
    //    timeAttack += Time.deltaTime;

    //    enemyAnimator.SetFloat("animatorEnemyRun", 0);

    //    if (timeAttack >= delayAttack)
    //    {
    //        CanAttack = true;
    //        timeAttack = 0;
    //    }

    //    if (CanAttack)
    //    {
    //        enemyAnimator.SetTrigger("animatorEnemyAttack");
    //        CanAttack = false;
    //    }
    //}

    public void Attack()
    {
        timeAttack += Time.deltaTime;

        enemyAnimator.SetFloat("animatorEnemyRun", 0);
        //enemyAnimator.SetTrigger("animatorEnemyAttack");
        //enemyAnimator.SetBool("Attack", true);

        if (timeAttack >= delayAttack)
        {
            enemyAnimator.SetTrigger("animatorEnemyAttack");
            //CanAttack = true;
            timeAttack = 0;
        }
    }

    public void ChangeStateEnemy(IStateEnemy newState)
    {
        currentState = newState;

        currentState.Enter(this);
    }

    public void CheckPlayer(int axisY)
    {
        if (facingRight)
        {
            hitInfo = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + axisY), Vector2.right, distance, layerMask);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    if(EnemyOutsideEdge && EnemyRangeAttack || !EnemyOutsideEdge)
                    {
                        EnemyTarget = playerObject;
                    }
                    Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + axisY), hitInfo.point, Color.black);
                }

                else if(hitInfo.collider.tag != "Player")
                {
                    EnemyTarget = null;

                    Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + axisY), hitInfo.point, Color.white);
                }
            }
            else
            {
                Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + axisY), new Vector3(transform.position.x, transform.position.y + axisY) + Vector3.right * distance, Color.green);
                EnemyTarget = null;
            }
        }
        else if (!facingRight)
        {
            hitInfo = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + axisY), Vector2.left, distance, layerMask);

            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    if (EnemyOutsideEdge && EnemyRangeAttack || !EnemyOutsideEdge)
                    {
                        EnemyTarget = playerObject;
                    }

                    Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + axisY), hitInfo.point, Color.black);
                }

                else if (hitInfo.collider.tag != "Player")
                {
                    EnemyTarget = null;

                    Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + axisY), hitInfo.point, Color.white);
                }
            }
            else
            {
                Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + axisY), new Vector3(transform.position.x, transform.position.y + axisY) + Vector3.left * distance, Color.green);
                EnemyTarget = null;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSword"))
        {
            if (!EnemyDie)
            {
                Debug.Log("Take");
                SoundManager.soundManagerInstance.PlaySound("Enemy_Hit");
                enemyAnimator.ResetTrigger("animatorEnemyAttack");
                TakeDamage(Player.PlayerInstance.damage);
                EnemyTarget = collision.gameObject;
                EnemyLookTarget();
            }
        }

        if (collision.CompareTag("Player"))
        {
            //StartCoroutine(Player.PlayerInstance.TakeDamage(damage));
            //Flip();
            EnemyTarget = collision.gameObject;
            EnemyLookTarget();
        }
    }
}
