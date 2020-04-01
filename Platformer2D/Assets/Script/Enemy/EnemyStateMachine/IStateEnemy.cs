using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateEnemy 
{
    //void Enter(EnemySwordman enemy);

    void Enter(EnemyBase enemy);

    void Execute();

    void OntriggerEnter2D(Collider2D collision);

    void Exit();
}
