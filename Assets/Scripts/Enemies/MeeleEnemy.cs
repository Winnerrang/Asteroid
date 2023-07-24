using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : Enemy
{
    public float _attackRange;

    protected override void Update()
    {
        if (m_isDie) return;
        base.Update();

        if (Vector2.Distance(transform.position, _target.position) < _attackRange)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        Debug.Log("Meele Attack");
    }
}
