using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordman : EnemyBase
{
    public override void Start()
    {
        base.Start();

        ChangeStateEnemy(new IdleState());
    }

    // Update is called once per frame
    public new void Update()
    {
        currentState.Execute();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSword"))
        {
            Debug.Log("Take");
            TakeDamage();
            EnemyTarget = collision.gameObject;
        }
    }

    #region
    //private void Move()
    //{
    //    if (EnemyTarget != null)
    //    {
    //        EnemyLookTarget();

    //        Walk();

    //        if(gameObject.transform.position.x <= leftEdge.position.x || gameObject.transform.position.x >= rightEdge.position.x)
    //        {
    //            EnemyTarget = null;
    //        }
    //    }


    //    if (EnemyTarget == null)
    //    {
    //        if (timeRun < delayRun)
    //        {
    //            timeRun += Time.deltaTime;
    //            EnemyRun();
    //        }

    //        if (timeRun >= delayRun)
    //        {
    //            EnemyIdle();
    //        }
    //    }
    //}

    //private void EnemyIdle()
    //{
    //    timeIdle += Time.deltaTime; 
    //    enemyAnimator.SetFloat("animatorEnemyRun", 0);
    //    if(timeIdle >= delayIdle)
    //    {
    //        ResetTimer();
    //    }
    //}

    //private void EnemyRun()
    //{
    //    Walk();
    //    ChangeDirection();
    //}
    #endregion
}
