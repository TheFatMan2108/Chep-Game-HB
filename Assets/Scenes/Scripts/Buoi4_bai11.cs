using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buoi4_bai11 : MonoBehaviour,IPointerClickHandler
{
    public Color[] colors;
    int index = 0;
    Image sp;
    public void OnPointerClick(PointerEventData eventData)
    {
       
        CheckColor(ref index);
        sp.color = colors[index];
    }

    private void CheckColor(ref int index)
    {
         index = Random.Range(0,colors.Length);
        if (sp.color == colors[index]) CheckColor(ref index);

    }

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<Image>();
        sp.color = colors[index];
    }

   
}
