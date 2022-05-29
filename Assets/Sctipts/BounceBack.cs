using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private float backspeed = 30f;
    private bool ýsCollision;
    Rigidbody rb;
    float force = 3f;

    Transform maxPosLimit;
    private void Start()
    {

        rb = GetComponent<Rigidbody>();


    }
    private void FixedUpdate()
    {


        if (ýsCollision)
        {

            if (transform.position.z >= (maxPosLimit.position.z - 7.6f))
            {
                Debug.Log(transform.position.z);
                speed = 0;

                rb.velocity = Vector3.back * backspeed;

                backspeed -= 1.221f;

                Debug.Log(backspeed);

                //rb.AddForce(new Vector3(0, 0, -force), ForceMode.Impulse);
            }
            else
            {

                
                backspeed = 30f;
                ýsCollision = false;

                Invoke("TimeDelay", 3.7f);


            }
        }
        else
        {   
            rb.velocity = Vector3.forward * speed;
        }
    }
    void TimeDelay()
    {
        speed = 10f;
    }

    public void SetIsCollision(bool conditionOfCollision)
    {
        ýsCollision=conditionOfCollision;
    }

    public void SetMaxPosLimit(Transform trans )
    {
        maxPosLimit = trans;
    }
}
