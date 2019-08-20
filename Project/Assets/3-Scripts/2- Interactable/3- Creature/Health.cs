// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Health : MonoBehaviour
// {
//     [SerializeField]
//     private int maxHealth = 100;
//     private int currentHealth;

//     private event Action<float> OnHealthPercentageChanged = delegate {};

//     private void OnEnable()
//     {
//         currentHealth = maxHealth;
//     }

//     public void ModifyHealth (int amount)
//     {
//         currentHealth += amount;

//         float currentHealthPercentage = (float)currentHealth / (float)maxHealth;
//         OnHealthPercentageChanged(currentHealthPercentage);
//     }

//     private void Update ()
//     {
//         if(Input.GetKeyDown(KeyCode.Space))
//         {
//             ModifyHealth(-10);
//         }
//     }
// }
