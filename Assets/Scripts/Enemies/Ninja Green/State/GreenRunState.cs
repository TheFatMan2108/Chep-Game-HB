using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRunState : GreenGroundState
{
    public GreenRunState(Rigidbody2D rb, Animator animator, StateController statePlayer, Enemy enemy, string name) : base(rb, animator, statePlayer, enemy, name)
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
    }
    public override void Update()
    {
        base.Update();
    }
}
