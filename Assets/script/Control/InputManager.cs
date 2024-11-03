using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero; //variaveis

    private bool submitPressed = false;

    private bool interactPressed = false;

    private static InputManager instance;

    private void Awake() //função
    {
       if(instance != null)
        {
            Debug.LogError("Tem mais de um Input na cena");
        }
        instance = this;
    }

    public static InputManager GetInstance()
    {
        return instance;

    }
        public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }



    public void IteractPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
            
            
        }else if (context.canceled)
        {
            interactPressed= false;
        }
    }
public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
           

        }else if (context.canceled)
        {
            submitPressed= false;
        }
    }
    public Vector2 GetMovediraction() 
    
    {
        return moveDirection;
    }
    public bool GetInteractPressed()
    {
        bool result = interactPressed;
    interactPressed = false;
        return result;
    
    }
    public bool GetSubmitpressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }
    public void RegisterSubmitPressed()
    {
        
        
        
        submitPressed = false;
    } 
}

//HSDV


