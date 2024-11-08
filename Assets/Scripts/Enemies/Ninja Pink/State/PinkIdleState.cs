using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkIdleState : StateParrentEnemy
{
    NinjaPink ninjaPink;
    public PinkIdleState(Rigidbody2D rb, Animator animator, StateController statePlayer, Enemy enemy, string name) : base(rb, animator, statePlayer, enemy, name)
    {
        ninjaPink = (NinjaPink)enemy;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Start()
    {
        base.Start();
        stateCounter = 5;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
        if (stateCounter < 0) ninjaPink.stateEnemy.ChangeState(ninjaPink.runState);
    }
}
