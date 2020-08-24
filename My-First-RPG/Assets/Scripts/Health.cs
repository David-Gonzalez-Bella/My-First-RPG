using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int baseHealth;
    private int currentHealth;
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
            else if(value > baseHealth) //If the modifyied health exceeds the top health
            {
                currentHealth = baseHealth; 
            }
            else //If the modifyied health is equal or below 0
            {
                currentHealth = 0;
                Destroy(this.gameObject);
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
    }
}
