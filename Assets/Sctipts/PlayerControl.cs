using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl _insatance;
    float _turnSpeed = 5f;
    float _movementLimit = 2.4f;

    private void Awake()
    {
        if (_insatance = null)
        {
            _insatance = this;
        }
    }
    private void Update()
    {
        MovementHorizontal();
    }
    void MovementHorizontal()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x< _movementLimit)
        {    
            transform.position += Vector3.right*Time.deltaTime*_turnSpeed;
            IsObjectMove();
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -_movementLimit)
        {
            transform.position += Vector3.left*Time.deltaTime*_turnSpeed;
            IsObjectMove();
        }
    }
    public bool IsObjectMove()
    {
        return true;
    }
    
}
