using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkGroundState : StateParrentEnemy
{
    protected NinjaPink ninjaPink;
    protected float xInput = 1;
    public PinkGroundState(Rigidbody2D rb, Animator animator, StateController statePlayer, Enemy enemy, string name) : base(rb, animator, statePlayer, enemy, name)
    {
        ninjaPink = (NinjaPink)enemy;
    }


    public override void Exit()
    {
        base.Exit();
        rb.velocity = Vector3.zero;
    }

    public override void Start()
    {
        base.Start();
        xInput = ninjaPink.transform.localScale.x;
        rb.velocity = new Vector3(0,rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        Flip();
    }
    protected virtual void Flip()
    {
        if (!ninjaPink.CheckGround() || ninjaPink.CheckWall())
        {
            xInput *= -1;
            ninjaPink.Flip(xInput);
            ninjaPink.stateEnemy.ChangeState(ninjaPink.idleState);
            rb.velocity = Vector2.zero;
            return;
        }
    }
}
