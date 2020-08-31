using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int baseHealth;
    private int currentHealth;
    public Image healthBar;
    public UnityEvent dieEvent; //This is not really necessary, we could do it with a reference to the GameObject´s animator, but its usefull to have an example of UnityEvents
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value > 0 && value <= baseHealth) //If the modifyied health is between 0 and the top health we can have
            {
                currentHealth = value;
            }
            else if (value > baseHealth) //If the modifyied health exceeds the top health
            {
                currentHealth = baseHealth;
            }
            else //If the modifyied health is equal or below 0
            {
                currentHealth = 0;
                dieEvent?.Invoke(); //The '?' check is just to avoid a possible error in case that the envent wasn´t dropped in the editor, but it will always invoke 
            }
        }
    }

    void Start()
    {
        currentHealth = baseHealth;
    }

    public void ModifyHealth(int quantity) //This metod will be used to take damage or to heal
    {
        CurrentHealth += quantity;
        if (healthBar != null)
            ModifyHealthBar();
    }

    public void DestroyCharacter() //Called during the character´s death animation
    {
        Destroy(this.gameObject);
    }

    public void ModifyHealthBar()
            {
        healthBar.fillAmount = (float)CurrentHealth / baseHealth;
    }
}
