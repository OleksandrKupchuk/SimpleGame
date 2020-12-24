using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeState : IStateEnemy
{
    //EnemySwordman enemySwordmanRange;

    EnemyBase enemySwordmanRange;
    //public void Enter(EnemySwordman enemy)
    //{
    //    enemySwordmanRange = enemy;
    //}

    public void Enter(EnemyBase enemy)
    {
        enemySwordmanRange = enemy;
    }

    public void Execute()
    {
        if(Player.Instance.transform.position.x < enemySwordmanRange.transform.position.x - 0.5f || Player.Instance.transform.position.x > enemySwordmanRange.transform.position.x + 0.5f)
        {
            //Debug.Log("pos player" + Player.PlayerInstance.transform.position.x);
            //Debug.Log("pos enemy" + enemySwordmanRange.transform.position.x);
            enemySwordmanRange.EnemyLookTarget();
        }
        //enemySwordmanRange.EnemyLookTarget();

        //Debug.Log("Range");

        if (enemySwordmanRange.EnemyTarget != null && !enemySwordmanRange.EnemyRangeAttack)
        {

            if (!enemySwordmanRange.EnemyAttack)
            {
                enemySwordmanRange.Walk();
            }
        }

        if (enemySwordmanRange.EnemyOutsideEdge)
        {
            if(enemySwordmanRange.EnemyTarget != null && enemySwordmanRange.EnemyRangeAttack)
            {
                EnemyRange();
            }

            else if(enemySwordmanRange.EnemyTarget != null && !enemySwordmanRange.EnemyRangeAttack)
            {
                //enemySwordmanRange.Flip();
                enemySwordmanRange.EnemyTarget = null;
            }
        }

        if (enemySwordmanRange.EnemyRangeAttack)
        {
            EnemyRange();
        }

        if (enemySwordmanRange.EnemyTarget == null)
        {
            enemySwordmanRange.ChangeStateEnemy(new IdleState());
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

    private void EnemyRange()
    {
        enemySwordmanRange.ChangeStateEnemy(new MeeleState());
    }
}
    
