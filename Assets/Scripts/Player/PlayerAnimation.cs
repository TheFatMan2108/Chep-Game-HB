using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
    }
    
    public void StopAction()
    {
        player.isBusy = false;
        player.statePlayer.ChangeState(player.playerIdleState);
    }
    public void StartAttack()
    {
        Collider2D[] colliders = player.CheckAttack();
        foreach (var hit in colliders)
        {
            if (hit.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                if(takeDamage == null) continue;
                takeDamage.TakeDamage(player.damage);
            }
        }
    }
    public void SpawnKunai()
    {
        player.SpawnKunai();
    }
    public void SpawnPlayer()
    {
        StartCoroutine(TimeSpawn(5f));
    }

    IEnumerator TimeSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        player.ReSpawn();
    }
}
