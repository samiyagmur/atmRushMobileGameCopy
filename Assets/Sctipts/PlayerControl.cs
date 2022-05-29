using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    
    float _turnSpeed = 2f;
    
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MovementHorizontal();
            StackMoney._instance.MoveListElements();
        }
        if (Input.GetButtonUp("Fire1"))
        {   
            MovementHorizontal();
            StackMoney._instance.MoveOrigin();
        }



    }
    void MovementHorizontal()
    {
        //if (Input.GetKey(KeyCode.D) && transform.position.x< _movementLimit)
        //{    
        //    transform.position += Vector3.right*Time.deltaTime*_turnSpeed;
        //    StackMoney._instance.MoveListElements();
            
        //}
        //if (Input.GetKey(KeyCode.A) && transform.position.x > -_movementLimit)
        //{
        //    Debug.Log("girdi");
        //    transform.position += Vector3.left*Time.deltaTime*_turnSpeed;
        //    StackMoney._instance.MoveListElements();
            
        //}
        //if (Input.GetKeyUp(KeyCode.D) && transform.position.x < _movementLimit)
        //{
        //    transform.position += Vector3.right * Time.deltaTime * _turnSpeed;
        //    StackMoney._instance.MoveOrigin();

        //}
        //if (Input.GetKeyUp(KeyCode.A) && transform.position.x > -_movementLimit)
        //{
        //    transform.position += Vector3.left * Time.deltaTime * _turnSpeed;
        //    StackMoney._instance.MoveOrigin();
        //}

        Vector3 mousePos=Input.mousePosition;
        mousePos.z = Camera.main.transform.localPosition.z;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            GameObject _char = StackMoney._instance._moneyStack[0];
            Vector3 hitVec=hit.point;
            hitVec.y = _char.transform.localPosition.y;
            hitVec.z = _char.transform.localPosition.z;

            _char.transform.localPosition = Vector3.MoveTowards(_char.transform.localPosition, hitVec, Time.deltaTime * _turnSpeed);
        }
    }
    public bool IsObjectMove()
    {
        return true;
    }
    
}
