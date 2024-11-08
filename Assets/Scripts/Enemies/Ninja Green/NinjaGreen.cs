using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class NinjaGreen : Enemy,ITakeDamage,IReSpawn
{
    public StateController stateController {  get; private set; }
    public GameObject kunai;
    #region State
    public GreenIdleState idleState;
    public GreenRunState runState;
    public GreenThrowKunaiState throwKunaiState;
    public GreenDeadState deadState;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateController = new StateController();
        idleState = new GreenIdleState(rb,animator,stateController,this,"Idle");
        runState = new GreenRunState(rb, animator, stateController, this, "Run");
        throwKunaiState = new GreenThrowKunaiState(rb, animator, stateController, this, "Throw");
        deadState = new GreenDeadState(rb, animator, stateController, this, "Dead");
    }
    private void Start()
    {
        stateController.InstallState(idleState);
        uiController.SetDefaufl(ogHealth);
    }
    private void FixedUpdate()
    {
        stateController.curentState.FixedUpdate();
    }
    private void Update()
    {
        stateController.curentState.Update();
    }

    public void SpawnKunai()
    {
        GameObject nKuinai = Instantiate(kunai, attackPoint.position, Quaternion.Euler(0, 0, -90));
        FlipKunai(nKuinai.GetComponent<SpriteRenderer>());
        Destroy(nKuinai, 10);
    }
    private void FlipKunai(SpriteRenderer sp)
    {
        if (transform.localScale.x == 1)
        {
            sp.flipY = false;
        }
        else
        {
            sp.flipY = true;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        uiController.SetHealth(currentHealth);
        SetFloatingText(damage.ToString());
        if (currentHealth < 0.1f)
        {
            stateController.ChangeState(deadState);
        }
    }

    public void ReSpawn()
    {
        transform.localPosition = ogPosition;
        isBusy = false;
        currentHealth = ogHealth;
        uiController.SetDefaufl(ogHealth);
        stateController.ChangeState(idleState);
    }
}
