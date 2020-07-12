using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    
    public void SetHealth(float health)
    {
        slider.value = (int)Mathf.Ceil(health);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = (int)Mathf.Ceil(health);
    }
}
