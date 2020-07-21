using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : CharacterBase
{
    //[SerializeField] Rigidbody2D bossRigidbody;
    [Header("Boss Components")]
    [SerializeField] Animator bossAnimator;
    [SerializeField] BoxCollider2D bossBoxCollider;

    [Header("Boss Image Health")]
    [SerializeField] Image imageHealth;

    [Header("Player component")]
    private GameObject player;
    private Transform playerTransform;
    private Collider2D[] playerCollider;

    [Header("Boss Parametrs")]
    [SerializeField] float jumpForce;
    [SerializeField] float attackRangeX;
    [SerializeField] LayerMask layerMask;
    public float timeFatique;
    public float timeAttack;
    public float delayAttack;
    public float timeQuake;
    //private int quakeHash = Animator.StringToHash("Quake");

    [HideInInspector] public float distanceY;
    [HideInInspector] [SerializeField] float distanceX;

    public GameObject Target { get; set; }
    public bool BossAttack { get; set; }
    public Rigidbody2D BossRigidbody { get; set; }
    public bool CanJump { get; set; }
    public bool IsFatigue { get; set; }

    public bool BossIsDead { get; set; }

    public bool BossCanRun { get; set; }

    public float CurrentFillAmount
    {
        get
        {
            return health / maxHealth;
        }
    }

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        BossRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerCollider = player.GetComponents<Collider2D>();

        imageHealth.fillAmount = CurrentFillAmount;

        BossCanRun = true;

        for (int countEnemyCollider = 0; countEnemyCollider < playerCollider.Length; countEnemyCollider++)
        {
            Physics2D.IgnoreCollision(bossBoxCollider, playerCollider[countEnemyCollider]);
        }

        //Debug.Log("hash quake = " + quakeHash);
    }

    void Update()
    {
        distanceX = transform.position.x - player.transform.position.x;
        distanceY = Mathf.Abs(transform.position.y - player.transform.position.y);
        //Debug.Log("distance " + distance);

        ResetAnimation();

        if (!BossIsDead)
        {
            StateMachine();

            EnemyLookTarget();

            IsGround();

            CheckLayer();
        }
    }

    public Vector3 ChangeSide()
    {
        if (facingRight)
        {
            return Vector3.right;
        }

        return Vector3.left;
    }

    public void EnemyLookTarget()
    {
        if (distanceX < 0 && !facingRight || distanceX > 0 && facingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        if (!IsFatigue)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            //transform.Rotate(0f, 180f, 0f);
        }
        //if (facingRight || !facingRight)
        //{
        //    canvasHealth.transform.localScale = new Vector3(canvasHealth.transform.localScale.x * -1, canvasHealth.transform.localScale.y, canvasHealth.transform.localScale.z);
        //}
    }

    private void StateMachine()
    {
        if(Mathf.Abs(distanceX) > attackRangeX)
        {
            StartCoroutine(RunState());
        }

        if(Mathf.Abs(distanceX) < attackRangeX)
        {
            StartCoroutine(RangeState());
        }
    }

    private IEnumerator IdleState()
    {
        Debug.Log("Idle");

        bossAnimator.SetFloat("animatorBossRun", -1);

        yield return null;
    }

    private IEnumerator RunState()
    {
        Debug.Log("Run");
        if(!BossAttack && IsGround() && !IsFatigue && BossCanRun)
        {
            Walk();
        }

        yield return null;
    }

    private IEnumerator RangeState()
    {
        Debug.Log("Range");

        if (Mathf.Abs(distanceX) < attackRangeX && distanceY < 2.4f)
        {
            StartCoroutine(AttackState());
        }

        if (Mathf.Abs(distanceX) < attackRangeX && distanceY > 2.4f && CanJump)
        {
            StartCoroutine(JumpState());
        }

        if(Mathf.Abs(distanceX) < attackRangeX && distanceY > 2.4f && !CanJump)
        {
            StartCoroutine(IdleState());
        }

        yield return null;
    }

    private IEnumerator AttackState()
    {
        Attack();

        yield return null;
    }

    private IEnumerator JumpState()
    {
        //Debug.Log("Jump");
        Jump();
        yield return null;
    }

    public void Walk()
    {
        //Debug.Log("Move");
        bossAnimator.SetFloat("animatorBossRun", 1);
        //transform.Translate(ChangeSide() * speed * Time.deltaTime);
        Vector2 target = new Vector2(playerTransform.position.x, BossRigidbody.position.y);
        Vector2 newPos = Vector2.MoveTowards(BossRigidbody.position, target, speed * Time.fixedDeltaTime);
        BossRigidbody.MovePosition(newPos);
    }

    private void Attack()
    {
        if (IsGround())
        {
            bossAnimator.SetFloat("animatorBossRun", -1);
            bossAnimator.SetTrigger("animatorBossAttack");
        }
    }

    public void Jump()
    {
        if (!BossAttack && IsGround() && CanJump && !IsFatigue)
        {
            Debug.Log("Jump");
            BossRigidbody.velocity = Vector2.up * jumpForce;
            bossAnimator.SetTrigger("animatorBossJump");
        }
    }

    public bool IsGround()
    {
        RaycastHit2D ray = Physics2D.Raycast(bossBoxCollider.bounds.center, Vector2.down, bossBoxCollider.bounds.extents.y + 0.1f, layerMask);

        Color rayColor;
        if(ray.collider != null)
        {
            rayColor = Color.blue;
        }

        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(bossBoxCollider.bounds.center, Vector2.down * (bossBoxCollider.bounds.extents.y + 0.1f), rayColor);

        return ray.collider != null;
    }

    private void ResetAnimation()
    {
        if (!IsGround())
        {
            bossAnimator.SetFloat("animatorBossRun", -1);
        }
    }

    private void CheckLayer()
    {
        if (!IsGround())
        {
            bossAnimator.SetLayerWeight(1, 1);
        }

        else
        {
            bossAnimator.SetLayerWeight(1, 0);
        }
    }

    private void TakeDamage(float damage)
    {
        if (!BossIsDead)
        {
            health -= damage;

            imageHealth.fillAmount = CurrentFillAmount;

            if (health <= 0)
            {
                bossAnimator.SetTrigger("animatorBossDie");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsFatigue)
        {
            if (collision.gameObject.CompareTag("PlayerSword"))
            {
                TakeDamage(player.GetComponent<Player>().damage);
            }
        }
    }
}
