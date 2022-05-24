using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyCollision : MonoBehaviour
{
    
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hee");
        if (other.gameObject.tag=="stackObject")
        {
            if (!StackMoney._instance._moneyStack.Contains(other.gameObject))
            {
                Debug.Log("girdi");
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "stackedObject";
                other.gameObject.AddComponent<MoneyCollision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;

                StackMoney._instance.StackMoneys(other.gameObject, StackMoney._instance._moneyStack.Count - 1);
            }
        }
        
        
        
        
        


    }
}
