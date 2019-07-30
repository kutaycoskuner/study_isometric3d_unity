using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                // Debug.Log("we hit" + hit.collider.name + " " + hit.point);

                // Move our player to what we hit 

                // Stop focusing any objects

            }
        }

        if(Input.GetMouseButton(1))  // 1 for right mouse button
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // check if we hit an interractable
                // if we did set it as our focus 

            }
        }
        
    }
}
