using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoi4_bai3 : MonoBehaviour
{
    public Transform[] points;
    private Vector3 tempPoint;
    private int index = 1;
    private void Start()
    {
        tempPoint = points[index].position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, tempPoint, 5f * Time.deltaTime);
        if (Vector3.Distance(transform.position, tempPoint) < 0.001f)
        {
            index++;
            if(index >= points.Length)index = 0;
            tempPoint = points[index].position;
        }
    }
}
