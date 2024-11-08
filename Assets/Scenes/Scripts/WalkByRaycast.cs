using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkByRaycast : MonoBehaviour
{
    public LayerMask wall;
    public float distance,speed=10f;
    float direction =1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(direction*speed*Time.deltaTime,transform.position.y));
        if (CheckWall())
        {
            direction *= -1;
            transform.localScale = new Vector3(direction,1,1);
        }
    }
    public RaycastHit2D CheckWall()=> Physics2D.Raycast(transform.position,Vector2.right,direction,wall);
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,transform.position+new Vector3(direction*distance,0,0));
    }
}
