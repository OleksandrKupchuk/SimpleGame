using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IStateEnemy
{
    private float delayRun = 4f;
    private float timeRun;
    //EnemySwordman enemySwordManRun;

    EnemyBase enemySwordManRun;
    //public void Enter(EnemySwordman enemy)
    //{
    //    enemySwordManRun = enemy;
    //}

    public void Enter(EnemyBase enemy)
    {
        enemySwordManRun = enemy;
    }

    public void Execute()
    {
        EnemyRun();

        if (enemySwordManRun.EnemyTarget != null)
        {
            enemySwordManRun.ChangeStateEnemy(new RangeState());
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

    private void EnemyRun()
    {
        timeRun += Time.deltaTime;

        enemySwordManRun.Walk();

        enemySwordManRun.ChangeDirection();

        //Debug.Log("Run");

        if(timeRun >= delayRun)
        {
            enemySwordManRun.ChangeStateEnemy(new IdleState());
        }
    }
}
