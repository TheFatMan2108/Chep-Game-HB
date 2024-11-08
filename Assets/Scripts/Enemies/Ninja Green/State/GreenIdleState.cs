using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenIdleState : GreenGroundState
{
    private float timeAttack = 0;
    public GreenIdleState(Rigidbody2D rb, Animator animator, StateController statePlayer, Enemy enemy, string name) : base(rb, animator, statePlayer, enemy, name)
    {
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
        if (ninjaGreen.CheckPlayer() && !ninjaGreen.isBusy && timeAttack < 0)
        {
            statePlayer.ChangeState(ninjaGreen.throwKunaiState);
            timeAttack = 1;
        }
        else if (stateCounter < 0)
        {
            xInput *= -1;
            ninjaGreen.Flip(xInput);
            statePlayer.ChangeState(ninjaGreen.idleState);
        }
        stateCounter -= Time.deltaTime;
        timeAttack -= Time.deltaTime;

    }
}
