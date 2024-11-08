using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoi4_bai8 : MonoBehaviour
{
    public Transform[] points;
    public float timeDelay;
    private Vector3 tempPoint;
    private int index = 1;
    Coroutine temp;
    bool isMove;
    void Start()
    {
        tempPoint = points[index].position;
        isMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isMove) return;
        transform.position = Vector3.MoveTowards(transform.position, tempPoint, 5f * Time.deltaTime);
        if (Vector3.Distance(transform.position, tempPoint) < 0.001f)
        {
                index++;
                if (index >= points.Length) index = 0;
                tempPoint = points[index].position;
                temp = StartCoroutine(Stop(timeDelay));
        }

    }
    IEnumerator Stop(float time)
    {
        isMove = false;
        yield return new WaitForSeconds(time);
        isMove = true;
        if(temp != null) temp=null;
    }
}
