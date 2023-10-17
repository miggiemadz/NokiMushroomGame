using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyStates
{
    public EnemyPatrol(WalkingEnemy walkingEnemy, EnemyStateMachine enemyStateMachine) : base(walkingEnemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(WalkingEnemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
