using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates
{
    // protected = public for this script, private for others
    // All states will have access to these variables
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;
    // coonstructor
    public EnemyStates(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void FrameUpdate () { }

    public virtual void PhysicsUpdate() { }

    public virtual void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType) { }

}
