// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class HealthBar : MonoBehaviour
// {
//     [SerializeField]
//     private Image foregroundImage;
//     [SerializeField]
//     private float updateSpeedSeconds =  0.5f;

//     private void Awake()
//     {
//         GetComponentInParent<Health>().OnHealthPercentageChanged += HandleHealthChanged;
//     }

//     private void HealthHandleChanged(float percentage)
//     {
//         StartCoroutine(ChangetoPercentage(percentage));
//     }

//     private IEnumerator ChangetoPercentage(float percentage)
//     {
//         float preChangePertentage = [foregroundImage.fillAmount];
//         float elapsed = 0f;

//         while(elapsed < updateSpeedSeconds)
//         {
//             elapsed += Time.deltaTime;
//             foregroundImage.fillAmount = Mathf.Lerp(preChangePercentage, percentage, elapsed / updateSpeedSeconds);
//             yield return null;
//         }
//     }

//     private void LateUpdate() 
//     {
//         transform.LookAt(Camera.main.transform);
//         transform.Rotate(0,180,0);    
//     }

// }
