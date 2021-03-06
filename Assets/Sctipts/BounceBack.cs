using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    [SerializeField] public float veloctySpeed = 10;
    private float backspeed = 30f;
    private bool ısCollision;
    Rigidbody rb;
    float force = 3f;
    Transform maxPosLimit;
    private void Start()
    {

        rb = GetComponent<Rigidbody>();


    }
    private void FixedUpdate()
    {
        //Debug.Log("Velocity :"+veloctySpeed);

        if (ısCollision)
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
                ısCollision = false;

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
        ısCollision=conditionOfCollision;
    }

    public void SetMaxPosLimit(Transform trans )
    {
        maxPosLimit = trans;
    }

    public void CanvasPosOnPlayer()
    {
        //gameObject.GetComponent<Canvas>();

        //TODO: Player Düşerken Canvas Text Onunla birlikte hareket edecek.

    }
    



}
