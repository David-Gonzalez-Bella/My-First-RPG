using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Atributes")]
public class Atributes : ScriptableObject //Attributes is only a bunch of data, so theres no need for this class to inherit from MonoBehaviour. Instead it will be an ScriptableObject, so any gameobject can have an "instance" of this data and choose its values for itself
{
    [Tooltip("Character´s speed")]
    [SerializeField] private float baseSpeed;

    [Tooltip("Character´s damage")]
    [SerializeField] private int baseDamage;

    //public enum Atribute { speed, damage, health };

    private int speedIncrease = 0;
    private int damageIncrease = 0;

    public float speed { get { return baseSpeed + speedIncrease; } }
    public int damage { get { return baseDamage + damageIncrease; } }

    /*
       public void ModifyAttribute(Atribute atribute, int quantity)
       {

           switch (atribute)
           {
               case Atribute.speed:
                   if (speedIncrease + quantity >= 0)
                       speedIncrease += quantity;
                   break;
               case Atribute.damage:
                   if (damageIncrease + quantity >= 0)
                       damageIncrease += quantity;
                   break;
               case Atribute.health:

                   break;
           }
       }
   */
    public void ModifyBaseSpeed()
    {
        baseSpeed++;
        Atributes_Texts.sharedInstance.UpdateAtribsTexts(baseDamage, baseSpeed);
    }
    public void ModifyBaseDamage()
    {
        baseDamage++;
        Atributes_Texts.sharedInstance.UpdateAtribsTexts(baseDamage, baseSpeed);
    }
}
