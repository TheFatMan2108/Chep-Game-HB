using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkRunState : PinkGroundState
{
    public PinkRunState(Rigidbody2D rb, Animator animator, StateController statePlayer, Enemy enemy, string name) : base(rb, animator, statePlayer, enemy, name)
    {
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Start()
    {
        base.Start();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (ninjaPink.CheckPlayer()) ninjaPink.stateEnemy.ChangeState(ninjaPink.zoneAttackState);
        else rb.velocity = new Vector2(ninjaPink.speed * xInput, rb.velocity.y);
    }
    public override void Update()
    {
        base.Update();
    }
   

}
