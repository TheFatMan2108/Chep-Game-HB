using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Enemy_Controller : MonoBehaviour
{
    private Slider healthBar;
    void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
    }

    public void SetDefaufl(float defaufl)
    {
        healthBar.maxValue = defaufl;
        healthBar.minValue = 0;
        healthBar.value = defaufl;
    }
    public void SetHealth(float health) => healthBar.value = health;
    public void FlipBar(float xInput)
    {
        if (xInput >0.01f)healthBar.direction = Slider.Direction.LeftToRight;
        else healthBar.direction = Slider.Direction.RightToLeft;
    }
}
