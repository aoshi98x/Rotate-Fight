using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningTopControl : MonoBehaviour
{
    [Header ("Spining Rotation")]
    Rigidbody spiningRb;
    [SerializeField] Vector3 angleVelocity;
    [SerializeField] float time;
    [SerializeField] int multiplier;
    [Space]
    [Header ("Spining Movement")]
    float movH, movZ;
    Vector3 moveInput;
    [SerializeField] float speedMov;
    [SerializeField] string controlH, controlV;
    
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
        ControlMovement();
        AttackMode();

        if(time <= 10.0f)
        {
            StoppedMode();
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
        
        if(time <= 5.0f)
        {
            spiningRb.constraints = RigidbodyConstraints.None;
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
}
