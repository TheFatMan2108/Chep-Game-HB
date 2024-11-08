using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Windows;

public class PinkZoneAttackState : PinkGroundState
{
    float timeAttack = 0;
    public PinkZoneAttackState(Rigidbody2D rb, Animator animator, StateController statePlayer, Enemy enemy, string name) : base(rb, animator, statePlayer, enemy, name)
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
        if (ninjaPink.CheckPlayer())
        {
            if (ninjaPink.CheckZoneAttack())
            {
                rb.velocity = Vector2.zero;
                timeAttack = 1;
                statePlayer.ChangeState(ninjaPink.attackState);
                return;
            }
        }
        if(timeAttack>0)timeAttack-=Time.deltaTime;
        rb.velocity = new Vector2(ninjaPink.speed * ninjaPink.transform.localScale.x * 1.5f, rb.velocity.y);
        base.Update();
    }
}
