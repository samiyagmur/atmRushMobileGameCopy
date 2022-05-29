using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyCollision : MonoBehaviour
{
    TransformOtherObject _instanceTransform;
    GameObject GameObjectMoney;
    UI_Manager _instanceUIManager;
    MoveForward _instanceMoveForw;
    PlayerAnimation _instancePlayerAnimation;
    BounceBack _ýnstanceBounceBack;

    private void Awake()
    {
        _instanceUIManager = FindObjectOfType<UI_Manager>();
        _instanceTransform = GetComponent<TransformOtherObject>();
        _instanceMoveForw = FindObjectOfType<MoveForward>();
        _instancePlayerAnimation = FindObjectOfType<PlayerAnimation>();
        _ýnstanceBounceBack = FindObjectOfType<BounceBack>();
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
        if (other.gameObject.tag == "Atm")
        {
            _instanceUIManager.controlAtmText();
            
            DestroyGameObject();



        }
        if (other.gameObject.tag == "ObstaclePendulum" || other.gameObject.tag == "ObstacleThorn")
        {
            _instancePlayerAnimation.AnimationControl(other);
            _ýnstanceBounceBack.SetIsCollision(true);
            _ýnstanceBounceBack.SetMaxPosLimit(other.gameObject.transform);

            if (gameObject.name == "M_Money")
            {
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }

            DestroyGameObject();
        }

    }

    private void DestroyGameObject()
    {
        if (gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag != "stackedMoney")
        {
            _instanceMoveForw.speed = 0;
        }
        

    }
    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.tag != "stackedMoney")
        {
            //_instanceMoveForw.speed = 0;
        }
        
    }





}
