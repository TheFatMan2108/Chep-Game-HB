using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : StateParrentPlayer
{
    public int currentCounter = 0;
    public float currentTime;

    public PlayerAttackState(Rigidbody2D rb, Animator animator, StateController statePlayer, Player player, string name) : base(rb, animator, statePlayer, player, name)
    {
    }

    public override void Start()
    {
        base.Start();
        if (currentCounter > 2||(currentTime+2)<Time.time) currentCounter = 0;
        animator.SetInteger("ComboCounter",currentCounter);
        currentCounter++;
        player.isBusy = true;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
        currentTime = Time.time;
    }
}
