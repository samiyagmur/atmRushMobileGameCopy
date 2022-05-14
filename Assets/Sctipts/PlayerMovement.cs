using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]private float speed=5;
    [SerializeField] private float sd = 50;

    private Camera cam;

    private void Start()
    {
        cam=Camera.main;
    }

    void Update()
    {
        transform.position+=Vector3.forward*Time.deltaTime*speed;
        if (Input.GetButton("Fire1"))
        {
            Move(); 
        }
        
    }

    void Move()
    {   
        Vector3 mousePos =Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            GameObject firstCube = StackMoney._insatance._stacts[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstCube.transform.localPosition.y;
            hitVec.z = firstCube.transform.localPosition.z;

            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.deltaTime * sd);
        }
    }
}
