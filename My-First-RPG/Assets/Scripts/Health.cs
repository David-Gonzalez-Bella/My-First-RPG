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
            if (value > 0 && value <= baseHealth)
            {
                currentHealth = value;
            }
            else if(value > baseHealth)
            {
                currentHealth = baseHealth;
            }
            else
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
