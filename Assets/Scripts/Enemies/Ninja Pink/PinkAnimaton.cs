using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkAnimaton : MonoBehaviour
{
    NinjaPink ninjaPink;
    void Start()
    {
        ninjaPink = GetComponentInParent<NinjaPink>();
    }
    public void StopAction()
    {
        ninjaPink.isBusy = false;
        ninjaPink.stateEnemy.ChangeState(ninjaPink.runState);
    }
    public void StartAttack()
    {
        Collider2D[] colliders = ninjaPink.CheckAttack();
        foreach (var hit in colliders)
        {
            if (hit.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                if (takeDamage == null) continue;
                takeDamage.TakeDamage(ninjaPink.damage);
            }
        }
    }
    public void ReSpawn()
    {
        StartCoroutine(TimeSpawn(5));
    }
    IEnumerator TimeSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        ninjaPink.ReSpawn();
    }
}
