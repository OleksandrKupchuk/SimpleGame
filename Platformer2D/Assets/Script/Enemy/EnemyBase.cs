﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyBase : CharacterBase
{
    public IStateEnemy currentState;

    protected float timeAttack;
    [SerializeField] protected float delayAttack;

    public bool CanAttack { get; set; }

    protected float dirPlayer;
    public GameObject EnemyTarget { get; set; }

    [SerializeField] protected float enemyRangeAttack;

    [SerializeField] int experienceForTheEnemy;

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

            return false;
        }
    }

    public bool EnemyOutsideEdge
    {
        get
        {
            if(transform.position.x >= rightEdge.position.x || transform.position.x <= leftEdge.position.x)
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

    [SerializeField] int takeDamage;

    public bool EnemyAttack { get; set; }

    public bool EnemyHit { get; set; }
    protected float directionEnemy;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        enemyAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (!EnemyDie)
        {
            enemyAnimator.SetTrigger("animatorEnemyHit");
            health -= takeDamage;

            if (health <= 0)
            {
                enemyAnimator.SetTrigger("animatorEnemyDie");
                Destroy(gameObject, 1.5f);
                Player.PlayerInstance.AddIndicatorForPlayer(experienceForTheEnemy);
            }
        }
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
        //transform.Rotate(0f, 180f, 0f);
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

    public Vector2 ChangeSide()
    {
        if (facingRight)
        {
            return Vector2.right;
        }

        return Vector2.left;
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

    public virtual void Attack()
    {
        timeAttack += Time.deltaTime;

        //enemyAnimator.SetFloat("animatorEnemyRun", 0);

        if (timeAttack >= delayAttack)
        {
            CanAttack = true;
            timeAttack = 0;
        }

        if (CanAttack)
        {
            enemyAnimator.SetTrigger("animatorEnemyAttack");
            CanAttack = false;
        }
    }

    public void ChangeStateEnemy(IStateEnemy newState)
    {
        currentState = newState;

        currentState.Enter(this);
    }
}
