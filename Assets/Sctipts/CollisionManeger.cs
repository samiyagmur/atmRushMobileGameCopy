using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManeger : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag =="stackObject")
        {
            Debug.Log("girdi");
            if (!StackMoney._insatance._stacts.Contains(other.gameObject)) 
            {
                
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "stackedObject";
                other.gameObject.AddComponent<CollisionManeger>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                StackMoney._insatance.StackMoneys(other.gameObject, StackMoney._insatance._stacts.Count - 1);
            }
        }
    }
}
