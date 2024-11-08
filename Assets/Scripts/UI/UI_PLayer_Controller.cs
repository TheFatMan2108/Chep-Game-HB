using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PLayer_Controller : MonoBehaviour
{
   public static UI_PLayer_Controller instance {  get; private set; }
   private Slider healthBar;
    private TextMeshProUGUI score;

    private void Awake()
    {
        if(instance == null)instance = this;
        else Destroy(gameObject);
        healthBar = GetComponentInChildren<Slider>();
        score = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        SetScore(GameManager.Instance.coin);
    }

    public void SetDefaufl(float defaufl)
    {
        healthBar.maxValue = defaufl;
        healthBar.minValue = 0;
        healthBar.value = defaufl;
    }
    public void SetHealth(float nHealth)=> healthBar.value = nHealth;
    public void SetScore(float nScore)=> score.text = nScore.ToString();
}
