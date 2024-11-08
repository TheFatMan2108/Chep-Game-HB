using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai5_move4huong : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public bool useRigidbody;
    Rigidbody2D rb;
    float x, y;
    Vector3 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (!useRigidbody)
        {
            direction = new Vector3(x, y, 0).normalized;
            transform.position = new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0) + transform.position;
        }
        else
        {
            rb.velocity = new Vector2 (x*speed, y*speed);
        }
    }
}
