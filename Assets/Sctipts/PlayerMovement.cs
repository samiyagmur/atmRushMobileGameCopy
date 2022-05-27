using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]private float speed=20;
    Rigidbody rb;
    private void Start()
    {   
        //gameObject.AddComponent<Rigidbody>(); 
        //rb=GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position+=Vector3.forward*Time.deltaTime*speed;
        //rb.velocity = new Vector3(0, 0, 10)*Time.deltaTime*speed;
       

        //rb.angularDrag
    }
}
