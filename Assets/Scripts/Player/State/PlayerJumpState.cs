using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : StateParrentPlayer
{
    public PlayerJumpState(Rigidbody2D rb, Animator animator, StateController statePlayer, Player player, string name) : base(rb, animator, statePlayer, player, name)
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
        if(player.CheckGround()) statePlayer.ChangeState(player.playerIdleState);
        else if (inputX != 0&&player.CheckGround()) statePlayer.ChangeState(player.runState);
    }
}
