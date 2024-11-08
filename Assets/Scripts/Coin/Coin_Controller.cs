using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    [SerializeField] private float amountCoin = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.TryGetComponent(out ITakeCoin coin);
        if (coin == null) return;
        coin.AddCoin(10);
        Destroy(gameObject);

    }
}
