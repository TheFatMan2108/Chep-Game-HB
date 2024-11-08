using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAnimation : MonoBehaviour
{
   private NinjaGreen ninjaGreen;

    private void Start()
    {
        ninjaGreen = GetComponentInParent<NinjaGreen>();
    }
    public void StopAction()
    {
        ninjaGreen.isBusy = false;
        ninjaGreen.stateController.ChangeState(ninjaGreen.idleState);
    }
    public void SpawnKunai()
    {
        ninjaGreen.SpawnKunai();
    }

    public void ReSpawn()
    {
        StartCoroutine(TimeSpawn(5));
    }
    IEnumerator TimeSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        ninjaGreen.ReSpawn();
    }
}
