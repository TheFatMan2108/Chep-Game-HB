using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    public float speed = 10f;
    public float jump = 10f;
    public float damage = 1;
    public float ogHealth = 10;
    public float currentHealth;
    public float distanceGround, attackDistance;
    public bool isBusy;
    public Transform groundCheck, attackPoint;
    public LayerMask groundMask;
    public Vector3 ogPosition = Vector3.zero;
    protected Rigidbody2D rb;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected GameObject floatingText;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = ogHealth;
    }

    public virtual void Flip(float inputX)
    {
        if (inputX != 0) transform.localScale = new Vector3(inputX, transform.localScale.y, 0);
    }
    public virtual TMP_Text SetFloatingText(string text)
    {
        Vector3 newPoint = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 2f),-1f);
        GameObject fText = Instantiate(floatingText, newPoint, Quaternion.identity,transform);
        fText.transform.position.Set(newPoint.x,newPoint.y,-1);
        fText.transform.localScale = transform.localScale; // flip text
        fText.GetComponent<TMP_Text>().text = text;
        Destroy(fText,2);
        return fText.GetComponent<TMP_Text>();
    }
    public virtual RaycastHit2D CheckGround() => Physics2D.Raycast(groundCheck.position, Vector3.down, distanceGround, groundMask);
    public Collider2D[] CheckAttack() => Physics2D.OverlapCircleAll(attackPoint.position, attackDistance);
    protected virtual void OnDrawGizmos()
    {
        // ti tinh sau
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, -distanceGround, 0));
        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);

    }
}
