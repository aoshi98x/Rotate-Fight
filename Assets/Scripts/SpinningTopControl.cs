using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningTopControl : MonoBehaviour
{
    
    
    [Header ("Spining Movement")]
    float movH, movZ;
    Vector3 moveInput;
    [SerializeField] float speedMov;
    [SerializeField] string controlH, controlV;
   
    [Space]
    [Header ("Spining Rotation")]
    Rigidbody spiningRb;
    [SerializeField] Vector3 angleVelocity;
    [SerializeField] float time;
    [SerializeField] int multiplier;
    [SerializeField] Transform spiningTrans;
    [SerializeField]GameObject baseSp;

    [Space]
    [Header("Attack-Defense")]
    [SerializeField] bool isPunch;
    [SerializeField] bool attackOn;
    [SerializeField] bool timeOut;

    
    void Start()
    {
        spiningRb = GetComponent<Rigidbody>();

    }

    private void Update() {
        
        movH = Input.GetAxisRaw(controlH);
        movZ = Input.GetAxisRaw(controlV);
    }

    void FixedUpdate()
    {
        time = time - Time.fixedDeltaTime;

        AttackMode();
        if (time <= 1.5f)
        {
            timeOut = true;
        }
        else
        {
            timeOut = false;
        }

        if (time <= 10.0f)
        {
            StoppedMode();
        }
        if(!timeOut)
        {
            ControlMovement();  
        }

    }

    void AttackMode()
    {
        Quaternion deltaRotation = Quaternion.Euler(angleVelocity* Time.fixedDeltaTime);
        spiningRb.MoveRotation(spiningRb.rotation * deltaRotation);
    }
    void StoppedMode()
    {

        angleVelocity = new Vector3(0,angleVelocity.y - Time.fixedDeltaTime*multiplier, 0);
        
        if(time <= 3.5f)
        {
            spiningRb.constraints = RigidbodyConstraints.None;
            baseSp.SetActive(false);
            
        }
        if (time <= 0.5f)
        {
            multiplier = 0;
            time = 0;
            angleVelocity.y = 0;
        }
    }
    void ControlMovement()
    {
        moveInput = new Vector3 (movH, moveInput.y, movZ);
        spiningRb.MovePosition(spiningRb.position + moveInput.normalized*speedMov*Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Spining"))
        {
            isPunch = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Spining"))
        {
            isPunch = false;
        }
    }
}
