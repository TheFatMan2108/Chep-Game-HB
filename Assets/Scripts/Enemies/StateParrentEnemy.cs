using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateParrentEnemy : IState
{
    protected float stateCounter;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected StateController statePlayer;
    protected Enemy enemy;
    protected string name;
    protected float inputX, inputY;
    public StateParrentEnemy(Rigidbody2D rb, Animator animator, StateController statePlayer, Enemy enemy, string name)
    {
        this.rb = rb;
        this.animator = animator;
        this.statePlayer = statePlayer;
        this.enemy = enemy;
        this.name = name;
    }

    public virtual void Exit()
    {
        animator.SetBool(name, false);
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void Start()
    {
        animator.SetBool(name, true);
    }

    public virtual void Update()
    {
        stateCounter-=Time.deltaTime;
    }
}
