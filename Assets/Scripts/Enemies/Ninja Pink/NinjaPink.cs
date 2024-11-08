using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaPink : Enemy,ITakeDamage,IReSpawn
{

    public StateController stateEnemy { get; private set; }
    #region State
    public PinkIdleState idleState;
    public PinkRunState runState;
    public PinkAttackState attackState;
    public PinkZoneAttackState zoneAttackState;
    public PinkDeadState deadState;
    #endregion
    protected override void Awake()
    {
        base.Awake();
        stateEnemy = new StateController();
        idleState = new PinkIdleState(rb,animator,stateEnemy,this,"Idle");
        runState = new PinkRunState(rb,animator,stateEnemy,this,"Run");
        zoneAttackState = new PinkZoneAttackState(rb,animator,stateEnemy,this,"Run");
        attackState = new PinkAttackState(rb,animator, stateEnemy, this, "Attack");
        deadState = new PinkDeadState(rb, animator, stateEnemy, this, "Dead");

    }
    private void Start()
    {
        stateEnemy.InstallState(idleState);
        uiController.SetDefaufl(ogHealth);
    }
    private void FixedUpdate()
    {
        stateEnemy.curentState.FixedUpdate();
    }
    private void Update()
    {
        stateEnemy.curentState.Update();
    }
    public override void Flip(float inputX)
    {
        base.Flip(inputX);
    }


    public override RaycastHit2D CheckGround()=> base.CheckGround();
    

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }

    public void TakeDamage(float damage)
    {
        currentHealth-=damage;
        uiController.SetHealth(currentHealth);
        SetFloatingText(damage.ToString());
        if (currentHealth < 0.1f)
        {
            stateEnemy.ChangeState(deadState);
        }
    }

    public void ReSpawn()
    {
        transform.localPosition = ogPosition;
        isBusy = false;
        currentHealth = ogHealth;
        uiController.SetDefaufl(ogHealth);
        stateEnemy.ChangeState(idleState);

    }
}

