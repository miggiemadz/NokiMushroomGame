using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates
{
    protected WalkingEnemy walkingEnemy;
    protected EnemyStateMachine enemyStateMachine;

    public EnemyStates(WalkingEnemy walkingEnemy, EnemyStateMachine enemyStateMachine)
    {
        this.walkingEnemy = walkingEnemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void AnimationTriggerEvent(WalkingEnemy.AnimationTriggerType triggerType) { }
}
