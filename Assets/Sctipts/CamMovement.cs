using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform _target;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position+offset, Time.deltaTime * 2);
    }
}
