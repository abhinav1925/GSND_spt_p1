using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    public InputAction DoorInteractInput;
    public bool InteractOnce;

    [SerializeField]
    private Animator m_Anim;
    private bool HasInteract;
    private bool CanInteract;

    private int Anim_DoorOpen;

    private void Awake()
    {
        DoorInteractInput.performed -= OnDoorInteract;
        DoorInteractInput.performed += OnDoorInteract;

        Anim_DoorOpen = Animator.StringToHash("DoorOpen");
    }

    private void OnEnable()
    {
        DoorInteractInput.Enable();
    }

    private void OnDisable()
    {
        DoorInteractInput.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if(other.CompareTag("Player"))
        {
            Debug.Log("PlayerEnter");
            CanInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.CompareTag("Player"))
        {
            Debug.Log("PlayerLeave");
            CanInteract = false;
        }
    }

    private void OnDoorInteract(InputAction.CallbackContext context)
    {
        if(InteractOnce)
        {
            if(CanInteract && !HasInteract)
            {
                if(context.performed)
                {
                    OnDoorOpen();
                    HasInteract = true;
                }
            }
        }
        else
        {
            if(CanInteract)
            {
                OnDoorOpen();
            }
        }
    }

    public void OnDoorOpen()
    {
        Debug.Log("DoorOpen");
        m_Anim.SetTrigger(Anim_DoorOpen);
    }

}
