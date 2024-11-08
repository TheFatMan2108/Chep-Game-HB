using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGroundState : StateParrentEnemy
{
    protected NinjaGreen ninjaGreen;
    protected float xInput = 1;
    public GreenGroundState(Rigidbody2D rb, Animator animator, StateController statePlayer, Enemy enemy, string name) : base(rb, animator, statePlayer, enemy, name)
    {
        ninjaGreen = (NinjaGreen)enemy;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Start()
    {
        base.Start();
        xInput = ninjaGreen.transform.localScale.x;
    }

    public override void Update()
    {
        base.Update();
    }
}
