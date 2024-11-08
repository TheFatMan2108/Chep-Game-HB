using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float distanceWall, distancePlayer;
    public Transform yourEyes;
    public LayerMask wallMask,playerMask;
    protected UI_Enemy_Controller uiController;
    protected override void Awake()
    {
        base.Awake();
        uiController = GetComponentInChildren<UI_Enemy_Controller>();
    }
    public override void Flip(float inputX)
    {
        base.Flip(inputX);
        uiController.FlipBar(inputX);
    }


    public override RaycastHit2D CheckGround()
    {
        return base.CheckGround();
    }
    public RaycastHit2D CheckWall() => Physics2D.Raycast(yourEyes.position, Vector2.right * transform.localScale.x, distanceWall, wallMask);
    public RaycastHit2D CheckZoneAttack() => Physics2D.Raycast(yourEyes.position, Vector2.right * transform.localScale.x, distanceWall, playerMask);
    public RaycastHit2D CheckPlayer() => Physics2D.Raycast(yourEyes.position, Vector2.right * transform.localScale.x, distancePlayer,playerMask);


    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(yourEyes.position, yourEyes.position + new Vector3(distancePlayer*transform.localScale.x, 0));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(yourEyes.position, yourEyes.position + new Vector3(distanceWall * transform.localScale.x, 0));
    }
}
