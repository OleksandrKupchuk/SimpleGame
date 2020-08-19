using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleState : IStateEnemy
{
    //EnemySwordman enemySwordmanMeele;
    EnemyBase enemySwordmanMeele;
    //public void Enter(EnemySwordman enemy)
    //{
    //    enemySwordmanMeele = enemy;
    //}

    public void Enter(EnemyBase enemy)
    {
        enemySwordmanMeele = enemy;
    }

    public void Execute()
    {
        //Debug.Log("Meele");
        if (enemySwordmanMeele.EnemyRangeAttack && !Player.PlayerInstance.PlayerDie)
        {
            enemySwordmanMeele.EnemyLookTarget();
            EnemyAttack();
        }
        
        if(enemySwordmanMeele.EnemyTarget != null && !enemySwordmanMeele.EnemyRangeAttack)
        {
            enemySwordmanMeele.ChangeStateEnemy(new RangeState());
        }

        if(enemySwordmanMeele.EnemyTarget == null)
        {
            enemySwordmanMeele.ChangeStateEnemy(new IdleState());
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

    private void EnemyAttack()
    {
        //Debug.Log("Meele");
        //enemySwordmanMeele.enemyAnimator.SetTrigger("animatorEnemyAttack");
        enemySwordmanMeele.Attack();
    }
}
