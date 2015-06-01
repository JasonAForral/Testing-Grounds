using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : Humanoid
{
    public List<Item> inventory = new List<Item>();
	public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    float sliderValue;
    //float floatHealth;

    private float healthDisplay;
    
    void Awake () {
        
        currentHealth = startingHealth;
        healthSlider.maxValue = maxHealth;
        //healthSlider.value = startingHealth;

        sliderValue = healthSlider.value;
        
        
	}

    void Update ()
    {
        if (sliderValue != currentHealth)
        {
            if ((currentHealth - sliderValue) > 0.5f || (sliderValue - currentHealth) > 0.5f)
            {
                sliderValue = Mathf.Lerp(sliderValue, currentHealth, Time.deltaTime * 2f);
                healthSlider.value = Mathf.RoundToInt(sliderValue);
            }
            else
            {
                sliderValue = currentHealth;
            }
            //Debug.Log(sliderValue + " : " + currentHealth + " => " + healthSlider.value);
            //Debug.Log();

        }
    }
}
