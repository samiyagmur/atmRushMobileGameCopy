using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float turnSpeed;
    private void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Debug.Log(input);

        transform.position = Vector3.left * Time.deltaTime * input * turnSpeed;

    }

}
