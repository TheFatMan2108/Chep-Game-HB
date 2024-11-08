using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : StateParrentPlayer
{
    public PlayerIdleState(Rigidbody2D rb, Animator animator, StateController statePlayer, Player player, string name) : base(rb, animator, statePlayer, player, name)
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
        if(inputX!=0)statePlayer.ChangeState(player.runState);
        if (!player.CheckGround()) statePlayer.ChangeState(player.jumpState);
    }
}