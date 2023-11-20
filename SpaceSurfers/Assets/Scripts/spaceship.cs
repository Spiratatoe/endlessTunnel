using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class spaceship : MonoBehaviour
{
    [Header("=== Ship Movement Settings ===")] 
    [SerializeField]
    private float yawTorque = 0f;
    [SerializeField]
    private float pitchTorque = 0f;
    [SerializeField]
    private float rollTorque = 0f;
    [SerializeField]
    private float thrust = 100f;
    [SerializeField]
    private float upThrust = 50f;
    [SerializeField]
    private float strafeThrust = 50f;
    
    [Header("=== Boost Settings ===")] 
    [SerializeField]
    private float maxBoostAmount = 20f;
    [SerializeField]
    private float boostDeprecationRate = 0.25f;
    [SerializeField]
    private float boostRechargeRate = 0.5f;
    [SerializeField]
    private float boostMultiplier = 5f;
    public bool boosting = false;
    public float currentBoostAmount;
    
    [SerializeField, Range(0.001f, 0.999f)]
    private float thrustGlideReduction = 0.5f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float upDownGlideReduction = 0.111f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float leftRightGlideReduction = 0.111f;
    float glide, verticalGlide, horizontalGlide = 0f;

    [Header("=== stats ===")] 
    public GameObject player;
    public float hp;
    public float maxHp;
    public float distanceTravelled;
    public float pts;
    public float currentMultiplier = 100f;
    
    private Rigidbody rb;
    
    //input values 
    private float thurst1D;
    private float strafe1D;
    private float upDown1D;
    private float roll1D;
    private Vector2 pitchYaw;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleBoosting();
        HandleMovement();
        CalculateScore();
    }

    void CalculateScore()
    {
        distanceTravelled = (player.transform.position.z - 8.39f) * currentMultiplier;
    }

    void HandleBoosting()
    {
        if (boosting && currentBoostAmount > 0f)
        {
            currentBoostAmount -= boostDeprecationRate;
            if (currentBoostAmount <= 0)
            {
                boosting = false;
            }
        }
        else
        {
            if (currentBoostAmount < maxBoostAmount)
            {
                currentBoostAmount += boostRechargeRate;
            }
        }
    }
    void HandleMovement()
    {
        // roll
        rb.AddRelativeTorque(Vector3.back * roll1D * rollTorque * Time.deltaTime);
        // pitch
        rb.AddRelativeTorque(Vector3.right * Mathf.Clamp(-pitchYaw.y,-1f,1f) * pitchTorque * Time.deltaTime);
        // yaw 
        rb.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYaw.x,-1f,1f) * yawTorque * Time.deltaTime);
        
        // Thurst 
        if (thurst1D > 0.1f )
        {
            float currentThrust = thrust;

            if (boosting)
            {
                currentThrust = thrust * boostMultiplier;
            }
            else
            {
                currentThrust = thrust;
            }
            
            
            rb.AddRelativeForce(Vector3.forward * thurst1D * currentThrust * Time.deltaTime);
            glide = thrust;
        }if(thurst1D < -0.1f)
        {
            // i dont want to be able to go backwards
            float currentThrust = thrust;

            if (boosting)
            {
                currentThrust = thrust * boostMultiplier;
            }
            else
            {
                currentThrust = thrust;
            }
            
            float slowDownSpeed = 0.1f;
            
            rb.AddRelativeForce(Vector3.forward * slowDownSpeed * currentThrust * Time.deltaTime);
        }
        else
        {
            
            rb.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);
            glide *= thrustGlideReduction;
        }

        
        // UP / DOWN 
        if (upDown1D > 0.1f || upDown1D < -0.1f)
        {
            rb.AddRelativeForce(Vector3.up * upDown1D * upThrust * Time.fixedDeltaTime);
            verticalGlide *= upDown1D * upThrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.up * verticalGlide * Time.fixedDeltaTime);
            verticalGlide *= upDownGlideReduction;
        }
        // strafing 
        if (strafe1D > 0.1f || strafe1D < -0.1f)
        {
            rb.AddRelativeForce(Vector3.right * strafe1D * upThrust * Time.fixedDeltaTime);
            horizontalGlide = strafe1D * strafeThrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.right * horizontalGlide * Time.fixedDeltaTime);
            horizontalGlide *= leftRightGlideReduction;
        }
    }
    
    #region Input Methods
    public void OnThrust(InputAction.CallbackContext context)
    {
        thurst1D = context.ReadValue<float>();
    }
    public void OnStrafe(InputAction.CallbackContext context)
    {
        strafe1D = context.ReadValue<float>();
    }
    public void OnUpDown(InputAction.CallbackContext context)
    {
        upDown1D = context.ReadValue<float>();
    }
    public void OnRoll(InputAction.CallbackContext context)
    {
        roll1D = context.ReadValue<float>();
    }
    public void OnPitchYaw(InputAction.CallbackContext context)
    {
        pitchYaw = context.ReadValue<Vector2>();
    }
    public void OnBoost(InputAction.CallbackContext context)
    {
        boosting = context.performed;
    }
    #endregion
}
