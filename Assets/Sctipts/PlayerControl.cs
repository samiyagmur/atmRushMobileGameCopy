using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl _insatance;
    
    float _turnSpeed = 2f;
    //float _movementLimit = 2.4f;

    private void Awake()
    {
        if (_insatance = null)
        {
            _insatance = this;
        }
        
    }
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
            GameObject firstMoney = StackMoney._instance._moneyStack[0];
            Vector3 hitVec=hit.point;
            hitVec.y = firstMoney.transform.localPosition.y;
            hitVec.z = firstMoney.transform.localPosition.z;

            firstMoney.transform.localPosition = Vector3.MoveTowards(firstMoney.transform.localPosition, hitVec, Time.deltaTime * _turnSpeed);
        }
    }
    public bool IsObjectMove()
    {
        return true;
    }
    
}
