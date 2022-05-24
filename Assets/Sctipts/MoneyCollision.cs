using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyCollision : MonoBehaviour
{
    
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag=="stackObject")
        {
            if (!StackMoney._instance._moneyStack.Contains(other.gameObject))
            {
               
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "stackedObject";
                other.gameObject.AddComponent<MoneyCollision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;

                StackMoney._instance.StackMoneys(other.gameObject, StackMoney._instance._moneyStack.Count - 1);
            }
        }

        if (other.gameObject.tag=="Door")
        {   
           
            
            
        }
        
        
        


    }
}
