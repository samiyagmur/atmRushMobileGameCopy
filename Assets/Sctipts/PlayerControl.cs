using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float turnSpeed=2;
    private void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Debug.Log(input);

        transform.position = Vector3.left * Time.deltaTime * input * turnSpeed;

    }

}
