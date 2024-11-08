using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class KunaiController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public float speed =10f;
    public float damage = 10;
    public GameObject fxAttack;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * (sp.flipY ? -1 : 1), 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        collision.transform.TryGetComponent(out ITakeDamage takeDamage);
        if (takeDamage == null) return;
        takeDamage.TakeDamage(damage);
        GameObject fx = Instantiate(fxAttack,transform.position,Quaternion.identity);
        Destroy(fx,2);
        Destroy(gameObject, 0.1f);
    }

}
