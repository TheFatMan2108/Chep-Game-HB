using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowKunaiState : StateParrentPlayer
{
    public PlayerThrowKunaiState(Rigidbody2D rb, Animator animator, StateController statePlayer, Player player, string name) : base(rb, animator, statePlayer, player, name)
    {
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Start()
    {
        base.Start();
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
}
