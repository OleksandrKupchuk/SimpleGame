using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyBase
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform startPositionArrow;

    public override void Start()
    {
        base.Start();
        ChangeStateEnemy(new IdleState());
    }

    public override void Update()
    {
        base.Update();

        CheckPlayer(0);
        //Debug.Log("FacingR = " + facingRight);
        //ChangeState(currentState);
        if (!EnemyDie)
        {
            StateEnemy();
        }

        Debug.Log("check target = " + EnemyTarget);
        Debug.Log("outside = " + EnemyOutsideEdge);
        Debug.Log("range = " + EnemyRangeAttack);
    }

    private void StateEnemy()
    {
        currentState.Execute();
    }

    #region
    //public void ChangeState(int currentState)
    //{
    //    if (currentState == stateIdle)
    //    {
    //        ArcherIdle();
    //    }

    //    else if (currentState == stateRun)
    //    {
    //        ArcherRun();
    //    }

    //    else if (currentState == stateRange)
    //    {
    //        ArcherRange();
    //    }

    //    else if (currentState == stateAttack)
    //    {
    //        ArcherAttack();
    //    }
    //}

    //public void ArcherIdle()
    //{
    //    enemyAnimator.SetFloat("animatorEnemyRun", 0);
    //    timeIdle += Time.deltaTime;

    //    Debug.Log("IdleArcher");
    //    //Debug.Log("time idle = " + timeIdle);

    //    if (timeIdle >= delayIdle && EnemyTarget == null)
    //    {
    //        timeRun = 0f;
    //        currentState = stateRun;
    //    }

    //    if (EnemyTarget != null)
    //    {
    //        currentState = stateRange;
    //    }
    //}

    //public void ArcherRun()
    //{
    //    timeRun += Time.deltaTime;

    //    Debug.Log("RunArcher");

    //    Walk();

    //    ChangeDirection();
    //    //Debug.Log("time run = " + timeRun);

    //    if (timeRun >= delayRun && EnemyTarget == null)
    //    {
    //        timeIdle = 0f;
    //        currentState = stateIdle;
    //    }

    //    if (EnemyTarget != null)
    //    {
    //        currentState = stateRange;
    //    }
    //}

    //public void ArcherRange()
    //{
    //    Walk();

    //    EnemyLookTarget();

    //    if (EnemyRangeAttack)
    //    {
    //        currentState = stateAttack;
    //    }

    //    if (EnemyOutsideEdge)
    //    {
    //        EnemyTarget = null;
    //    }

    //    if (EnemyTarget == null)
    //    {
    //        timeIdle = 0f;
    //        currentState = stateIdle;
    //    }

    //    Debug.Log("RangeArcher");
    //}

    //public void ArcherAttack()
    //{
    //    Debug.Log("ArcherAttack");

    //    Attack();

    //    if (!EnemyRangeAttack)
    //    {
    //        EnemyAttack = false;
    //        currentState = stateRange;
    //    }

    //    if (EnemyOutsideEdge)
    //    {
    //        timeIdle = 0f;
    //        currentState = stateIdle;
    //    }
    //}
    #endregion
    //method is responsible for creating and directing arrow
    public void FireArrow()
    {
        if (facingRight)
        {
            //enemyAnimator.SetTrigger("animatorEnemyAttack");
            GameObject arrow = Instantiate(arrowPrefab, startPositionArrow.position, Quaternion.identity); //create arrow
            arrow.GetComponent<EnemyArrowMove>().ArrowInitialization(Vector2.right); //convey the direction vector
        }

        else
        {
            GameObject arrow = Instantiate(arrowPrefab, startPositionArrow.position, Quaternion.Euler(new Vector3(0f, 180f, 0f))); //set 180 on Y when the enemy looks to the left
            arrow.GetComponent<EnemyArrowMove>().ArrowInitialization(Vector2.left);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("PlayerSword"))
    //    {
    //        Debug.Log("Take");
    //        TakeDamage();
    //        EnemyTarget = collision.gameObject;
    //    }

    //    if (collision.CompareTag("Player"))
    //    {
    //        Debug.Log("collision = " + collision.gameObject);
    //        //TakeDamage();
    //        EnemyTarget = collision.gameObject;
    //    }
    //}
}
