using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateParrentPlayer : IState
{
    protected float stateCounter;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected StateController statePlayer;
    protected Player player;
    protected string name;
    protected float inputX,inputY;
    public StateParrentPlayer( Rigidbody2D rb,Animator animator, StateController statePlayer, Player player, string name)
    {
        this.rb = rb;
        this.animator = animator;
        this.statePlayer = statePlayer;
        this.player = player;
        this.name = name;
    }

    public virtual void Exit()
    {
        animator.SetBool(name, false);
    }

    public virtual void FixedUpdate()
    {
        rb.velocity = new Vector2(player.speed * inputX, rb.velocity.y);
    }

    public virtual void Start()
    {
        animator.SetBool(name, true);
        player.isBusy = false;
    }

    public virtual void Update()
    {
        stateCounter--;
        inputX = player.Move().ReadValue<Vector2>().x;
        inputY = rb.velocity.y;
        animator.SetFloat("yVelocity",inputY);
        player.Flip(inputX);
    }
}
