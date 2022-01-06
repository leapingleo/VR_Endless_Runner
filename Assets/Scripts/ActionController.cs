using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionController : MonoBehaviour
{
    // Start is called before the first frame update
    private ActionBasedController controller;
    public InputAction leftAcceleration;
    public InputAction rightAcceleration;
    public InputAction leftSecondaryAction;
    public InputAction leftGripAction;

    public InputAction leftTriggerAction;
    public InputAction rightTriggerAction;
    public InputAction rightGripAction;
    public InputAction rightMainButtonAction;
    public InputAction rightSecondaryButtonAction;
    public InputAction leftEyeAction;
    public InputAction rightEyeAction;
    public static ActionController Instance;
    public bool leftSecondaryButtonPressed;
    public bool leftGripPressed;

    public bool rightMainButtonPressed;
    public bool rightSecondaryButtonPressed;
    public bool rightGripPressed;

    public bool leftSecondaryButtonLifted;
    public bool rightSecondaryButtonLifted;

    public bool leftTriggerPressed;
    public bool rightTriggerPressed;
    public float leftAccelerationValue;
    public float rightAccelerationValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        leftSecondaryButtonLifted = false;
        rightSecondaryButtonLifted = false;

    }


    void Start()
    {
        /*
          FOUR input actions added;
          *.perfored means the button is pressed
          *.canceled means the button is released.
         */
        rightGripAction.performed += RightGripActionPerformed;
        rightGripAction.canceled += RightGripActionCanceled;

        leftTriggerAction.performed += LeftTriggerPerformed;
        leftTriggerAction.canceled += LeftTriggerCanceled;

        rightTriggerAction.performed += RightTriggerPerformed;
        rightTriggerAction.canceled += RightTriggerCanceled;

        rightMainButtonAction.performed += RightMainButtonPerformed;
        rightMainButtonAction.canceled += RightMainButtonCanceled;

        rightSecondaryButtonAction.performed += RightSecondaryButtonPerformed;
        rightSecondaryButtonAction.canceled += RightSecondaryButtonCanceled;

        leftSecondaryAction.performed += LeftSecondaryButtonPerformed;
        leftSecondaryAction.canceled += LeftSecondaryButtonCanceled;

        leftGripAction.performed += LeftGripActionPerformed;
        leftGripAction.canceled += LeftGripActionCanceled;

        leftAcceleration.performed += LeftAccelerationPerformed;
        rightAcceleration.performed += RightAccelerationPerformed;
    }

    private void LeftAccelerationPerformed(InputAction.CallbackContext obj)
    {
        leftAccelerationValue = leftAcceleration.ReadValue<Vector3>().magnitude;
       // Debug.Log(leftAccelerationValue);
    }

    private void RightAccelerationPerformed(InputAction.CallbackContext obj)
    {
        rightAccelerationValue = rightAcceleration.ReadValue<Vector3>().magnitude;
       // Debug.Log(rightAccelerationValue);
    }

    
    private void LeftGripActionPerformed(InputAction.CallbackContext obj)
    {
        leftGripPressed = true;
    }

    private void LeftGripActionCanceled(InputAction.CallbackContext obj)
    {
        leftGripPressed = false;
    }

    private void LeftSecondaryButtonCanceled(InputAction.CallbackContext obj)
    {
        leftSecondaryButtonPressed = false;

        leftSecondaryButtonLifted = true;
    }

    private void LeftSecondaryButtonPerformed(InputAction.CallbackContext obj)
    {
       
        leftSecondaryButtonPressed = true;
    }

    public Vector3 LeftEyePosition()
    {
        return leftEyeAction.ReadValue<Vector3>();
    }

    public Vector3 RightEyePosition()
    {
        return rightEyeAction.ReadValue<Vector3>();
    }

    private void RightGripActionPerformed(InputAction.CallbackContext obj)
    {
        rightGripPressed = true;
    
       // GameManager.Instance.debugText = "Grip pressed";
    }

    private void RightGripActionCanceled(InputAction.CallbackContext obj)
    {
        rightGripPressed = false;
      //  GameManager.Instance.debugText = "-";
    }


    private void RightSecondaryButtonCanceled(InputAction.CallbackContext obj)
    {
       // GameManager.Instance.debugText = "-";
        rightSecondaryButtonPressed = false;
        rightSecondaryButtonLifted = true;
        //Debug.Log(rightSecondaryButtonLifted);
    }

    private void RightSecondaryButtonPerformed(InputAction.CallbackContext obj)
    {
       // GameManager.Instance.debugText = "secondary button \npressed";
        
        rightSecondaryButtonPressed = true;
    }

    private void RightMainButtonCanceled(InputAction.CallbackContext obj)
    {
      //  GameManager.Instance.debugText = "-";
        rightMainButtonPressed = false;
    }

    private void RightMainButtonPerformed(InputAction.CallbackContext obj)
    {
       
        float v = rightMainButtonAction.ReadValue<float>();
        rightMainButtonPressed = true;
        Debug.Log("pressed");
    }

    private void LeftTriggerPerformed(InputAction.CallbackContext obj)
    {
        // GameManager.Instance.debugText = "trigger pressed";
        leftTriggerPressed = true;
    }

    private void LeftTriggerCanceled(InputAction.CallbackContext obj)
    {
        // GameManager.Instance.debugText = "-";
        leftTriggerPressed = false;
    }

     private void RightTriggerPerformed(InputAction.CallbackContext obj)
    {
        // GameManager.Instance.debugText = "trigger pressed";
        rightTriggerPressed = true;
    }

    private void RightTriggerCanceled(InputAction.CallbackContext obj)
    {
        // GameManager.Instance.debugText = "-";
        rightTriggerPressed = false;
    }


    

    private void SelectActionCanceled(InputAction.CallbackContext obj)
    {
        
    }

    private void SelectActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       
    }


    void OnEnable()
    {
        leftGripAction.Enable();
        leftSecondaryAction.Enable();

        rightMainButtonAction.Enable();
        rightSecondaryButtonAction.Enable();
        rightGripAction.Enable();
        leftTriggerAction.Enable();
        rightTriggerAction.Enable();

        leftEyeAction.Enable();
        rightEyeAction.Enable();
        leftAcceleration.Enable();
        rightAcceleration.Enable();
    }

    void OnDisable()
    {
        leftGripAction.Disable();
        leftSecondaryAction.Disable();

        rightMainButtonAction.Disable();
        rightSecondaryButtonAction.Disable();
        rightGripAction.Disable();
        leftTriggerAction.Disable();
        rightTriggerAction.Disable();

        leftEyeAction.Disable();
        rightEyeAction.Disable();
        leftAcceleration.Disable();
        rightAcceleration.Disable();
    }
}
