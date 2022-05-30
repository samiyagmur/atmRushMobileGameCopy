using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyCollision : MonoBehaviour
{
    TransformOtherObject _ýnstanceTransform;
    UI_Manager _ýnstanceUIManager;
    MoveForward _ýnstanceMoveForw;
    PlayerAnimation _ýnstancePlayerAnimation;
    BounceBack _ýnstanceBounceBack;

    private void Awake()
    {
        _ýnstanceUIManager = FindObjectOfType<UI_Manager>();
        _ýnstanceTransform = FindObjectOfType<TransformOtherObject>();
        _ýnstanceMoveForw = FindObjectOfType<MoveForward>();
        _ýnstancePlayerAnimation = FindObjectOfType<PlayerAnimation>();
        _ýnstanceBounceBack = FindObjectOfType<BounceBack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="FinisLine")
        {
            //Oyun sonu bool IsGameFinish=true;
            _ýnstanceMoveForw.speed = 0;
            
            _ýnstanceBounceBack.veloctySpeed = 0;
            _ýnstancePlayerAnimation.GetComponent<PlayerAnimation>().enabled = false;
        }
        
        if (other.gameObject.tag== "stackMoney" )
        {
            if (!StackMoney._instance._moneyStack.Contains(other.gameObject))
            {
                //TransformOtherObject.stacableObject.money 
                
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "stackedMoney";
                other.gameObject.AddComponent<MoneyCollision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                StackMoney._instance.StackMoneys(other.gameObject, StackMoney._instance._moneyStack.Count - 1);
                

            }
        }
        if (other.gameObject.tag == "Atm")
        {
            _ýnstanceUIManager.controlAtmText();
            
            DestroyGameObject();



        }
        if (other.gameObject.tag == "ObstaclePendulum" || other.gameObject.tag == "ObstacleThorn")
        {
            _ýnstancePlayerAnimation.AnimationControl(other);
            _ýnstanceBounceBack.SetIsCollision(true);
            _ýnstanceBounceBack.SetMaxPosLimit(other.gameObject.transform);

            if (gameObject.name == "M_Money")
            {
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }

            DestroyGameObject();
        }
        if (other.gameObject.name =="Door")
        {

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
            _ýnstanceMoveForw.speed = 0;
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
