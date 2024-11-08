using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button button;
    Data data;
    void Start()
    {
        data = new Data();
        data.coin = 9999;
        button.onClick.AddListener(Save);
    }

    // Update is called once per frame
   public void Save()
    {
       string thisData= JsonUtility.ToJson(data);
        Debug.Log(thisData);
    }
}
