using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyCollision : MonoBehaviour
{
    TransformOtherObject _instanceTransform;
    GameObject GameObjectMoney;
    UI_Manager _instanceUIManager;
    
    private void Awake()
    {
        _instanceUIManager = FindObjectOfType<UI_Manager>();
        _instanceTransform = GetComponent<TransformOtherObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag== "stackMoney" )
        {
            if (!StackMoney._instance._moneyStack.Contains(other.gameObject))
            {
                GameObjectMoney = other.gameObject;
                GameObjectMoney.GetComponent<BoxCollider>().isTrigger = false;
                GameObjectMoney.tag = "stackedMoney";
                GameObjectMoney.AddComponent<MoneyCollision>();
                GameObjectMoney.AddComponent<Rigidbody>();
                GameObjectMoney.GetComponent<Rigidbody>().isKinematic = true;
                GameObjectMoney.GetComponent<Rigidbody>().useGravity = false;
                StackMoney._instance.StackMoneys(GameObjectMoney, StackMoney._instance._moneyStack.Count - 1);
                

            }
        }
        if (other.gameObject.tag =="Atm")
        {
            _instanceUIManager.controlAtmText(gameObject);
        }

    }
    
    
   

}
