using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] Color[] colors;
    int index = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            index++;
            if(index >=colors.Length) index = colors.Length-1;
            GetComponent<SpriteRenderer>().color = colors[index];
        }
    }
}
