using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    public Interactable focus;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        // If left click
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
                RemoveFocus();
            }
        }

        // If right click
        if(Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 

            if(Physics.Raycast(ray, out hit, 100))
            {
                // check if we hit an interractable
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();
                // if we did set it as our focus
                if(interactableObject != null)
                {
                    SetFocus(interactableObject);
                } 
                else
                {
                    RemoveFocus();
                }

            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDeFocused();
            }

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            {
                focus.OnDeFocused();
            }
            
        focus = null;
        motor.StopFollowingTarget();
    }

}
