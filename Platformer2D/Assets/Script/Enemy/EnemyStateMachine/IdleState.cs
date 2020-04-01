using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IStateEnemy
{
    private float delayIdle;
    private float timeIdle = 0;

    //EnemySwordman enemySwordmanIdle;
    EnemyBase enemySwordmanIdle;

    //public void Enter(EnemySwordman enemy)
    //{
    //    delayIdle = UnityEngine.Random.Range(2f, 4f);
    //    enemySwordmanIdle = enemy;
    //}

    public void Enter(EnemyBase enemy)
    {
        delayIdle = UnityEngine.Random.Range(2f, 4f);
        enemySwordmanIdle = enemy;
    }

    public void Execute()
    {
        EnemyIdle(delayIdle);

        if(enemySwordmanIdle.EnemyTarget != null)
        {
            enemySwordmanIdle.ChangeStateEnemy(new RangeState());
        }
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void OntriggerEnter2D(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    private void EnemyIdle(float delayIdleEnemy)
    {
        enemySwordmanIdle.enemyAnimator.SetFloat("animatorEnemyRun", 0);
        timeIdle += Time.deltaTime;
        //Debug.Log("Idle");
        if (timeIdle >= delayIdleEnemy)
        {
            enemySwordmanIdle.ChangeStateEnemy(new RunState());
        }
    }
}
