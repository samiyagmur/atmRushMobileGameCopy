using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]private float speed=5;
    
    
    void Update()
    {
        transform.position+=Vector3.forward*Time.deltaTime*speed;
    }
}
