using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Script used for the plane controller
    // Start is called before the first frame update

    //How to add key bindings for controller
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 5f;
    [SerializeField] float xRange = 1.5f;
    [SerializeField] float yRange = 1.5f;
    
    [SerializeField] float positionPitchFactor = 0f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 30f;
    [SerializeField] float controlRollFactor = -20f;
  
    float xThrow, yThrow;
 
    void Update()
    {
        // float horizontalThrow = movement.ReadValue<Vector2>().x;
        // float verticalThrow = movement.ReadValue<Vector2>().y;

        ProcessTranslation();
        ProcessRotation();

    }
    private void ProcessRotation()
    {
       
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
       
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    
    
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

}
