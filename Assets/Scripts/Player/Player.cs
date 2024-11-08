using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity,ITakeDamage,IReSpawn,ITakeCoin
{
    public GameObject kuinai;
    public Transform kunaiPoint;
    public StateController statePlayer { get; private set; }
    [SerializeField]
    private Controller action;
    #region State
    public PlayerIdleState playerIdleState;
    public PlayerRunState runState;
    public PlayerJumpState jumpState;
    public PlayerAttackState attackState;
    public PlayerThrowKunaiState throwKunaiState;
    public PlayerDeadState deadState;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        statePlayer = new StateController();
        rb = GetComponent<Rigidbody2D>();
        action = new Controller();
        playerIdleState = new PlayerIdleState(rb, animator, statePlayer, this, "Idle");
        runState = new PlayerRunState(rb, animator, statePlayer, this, "Run");
        jumpState = new PlayerJumpState(rb, animator, statePlayer, this, "Jump");
        attackState = new PlayerAttackState(rb, animator, statePlayer, this, "Attack");
        throwKunaiState = new PlayerThrowKunaiState(rb, animator, statePlayer, this, "Throw");
        deadState = new PlayerDeadState(rb, animator, statePlayer, this, "Dead");
    }
    void Start()
    {
        statePlayer.InstallState(playerIdleState);
        UI_PLayer_Controller.instance.SetDefaufl(ogHealth);
        Move().Enable();
        Jump().Enable();
        Attack().Enable();
        ThrowKunai().Enable();
        Jump().started += JumpAction;
        Attack().started += AttackAction;
        ThrowKunai().started += ThrowKunaiAction;

    }
    private void FixedUpdate()
    {
        statePlayer.curentState.FixedUpdate();
    }
    void Update()
    {
        statePlayer.curentState.Update();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UI_PLayer_Controller.instance.SetHealth(currentHealth);
        SetFloatingText(damage.ToString());
        if (currentHealth < 0.1f)
        {
            // lam gi do khi chet
            statePlayer.ChangeState(deadState);
            Move().Disable();
            Jump().Disable();
            Attack().Disable();
            ThrowKunai().Disable();
            Jump().started -= JumpAction;
            Attack().started -= AttackAction;
            ThrowKunai().started -= ThrowKunaiAction;
        }
    }
    public void ReSpawn()
    {
        transform.position = ogPosition;
        isBusy = false;
        currentHealth = ogHealth;
        UI_PLayer_Controller.instance.SetDefaufl(ogHealth);
        statePlayer.ChangeState(playerIdleState);
        Move().Enable();
        Jump().Enable();
        Attack().Enable();
        ThrowKunai().Enable();
        Jump().started += JumpAction;
        Attack().started += AttackAction;
        ThrowKunai().started += ThrowKunaiAction;
    }
    public void JumpAction(InputAction.CallbackContext callback)
    {
        if (CheckGround())
        {
            statePlayer.ChangeState(jumpState);
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
    public void AttackAction(InputAction.CallbackContext callback)
    {
        if (isBusy) return;
        statePlayer.ChangeState(attackState);
    }
    public void ThrowKunaiAction(InputAction.CallbackContext callback)
    {
        if (isBusy) return;
        statePlayer.ChangeState(throwKunaiState);
    }
    public void SpawnKunai()
    {
        GameObject nKuinai = Instantiate(kuinai, kunaiPoint.position, Quaternion.Euler(0, 0, -90));
        FlipKunai(nKuinai.GetComponent<SpriteRenderer>());
        Destroy(nKuinai, 10);
    }
    public InputAction Move() => action.PlayerController.Move;
    public InputAction Jump() => action.PlayerController.Jump;
    public InputAction Attack() => action.PlayerController.Attack;
    public InputAction ThrowKunai() => action.PlayerController.ThrowKunai;
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
    public override void Flip(float inputX)
    {
        base.Flip(inputX);
    }

    public override RaycastHit2D CheckGround()
    {
        return base.CheckGround();
    }

    public void AddCoin(float coin)
    {
        GameManager.Instance.AddCoin(coin);
        UI_PLayer_Controller.instance.SetScore(GameManager.Instance.coin);
        GameManager.Instance.SaveGame();
    }

    public void RemoveCoin(float coin)
    {
        GameManager.Instance.RemoveCoin(coin);
        UI_PLayer_Controller.instance.SetScore(GameManager.Instance.coin);
        GameManager.Instance.SaveGame();
    }
}
