using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Transform postA, postB;
    [SerializeField] private float speed = 5f;
    private Vector3 tempPost;
    private Rigidbody2D rb;
    private float goToB = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        tempPost = postB.position;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        /*if(Vector2.Distance(transform.position, tempPost) <1f)
        {
            goToB *=-1;

            if(goToB==-1)
                tempPost = postA.position;
            else tempPost = postB.position;
        }
        rb.velocity = new Vector2(speed * goToB, 0);*/
    }
    void Update()
    {
        if (transform.position == tempPost)
        {
            goToB *= -1;

            if (goToB == -1)
                tempPost = postA.position;
            else tempPost = postB.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, tempPost, speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            if (player != null) player.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            if (player != null) StartCoroutine(SetNull(player));
        }
    }
    IEnumerator SetNull(Player player)
    {
        yield return null;
        player.transform.SetParent(null);
    }
}
