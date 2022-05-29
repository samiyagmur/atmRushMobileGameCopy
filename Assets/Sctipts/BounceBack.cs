using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    [SerializeField] private float veloctySpeed = 10;
    private float backspeed = 30f;
    private bool ęsCollision;
    Rigidbody rb;
    float force = 3f;

    Transform maxPosLimit;
    private void Start()
    {

        rb = GetComponent<Rigidbody>();


    }
    private void FixedUpdate()
    {
        Debug.Log("Velocity :"+veloctySpeed);

        if (ęsCollision)
        {

            if (transform.position.z >= (maxPosLimit.position.z - 5f))
            {
                
                veloctySpeed = 0;

                rb.velocity = Vector3.back * backspeed;

                backspeed -= 1.221f;

                

              
            }
            else
            {

                
                backspeed = 30f;
                ęsCollision = false;

                Invoke("TimeDelay", 3.7f);


            }
        }
        else
        {   
            rb.velocity = Vector3.forward * veloctySpeed;
        }
    }
    void TimeDelay()
    {
        veloctySpeed = 10f;
    }

    public void SetIsCollision(bool conditionOfCollision)
    {
        ęsCollision=conditionOfCollision;
    }

    public void SetMaxPosLimit(Transform trans )
    {
        maxPosLimit = trans;
    }
}
