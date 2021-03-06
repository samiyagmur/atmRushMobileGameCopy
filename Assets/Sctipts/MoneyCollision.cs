using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyCollision : MonoBehaviour
{
    TransformOtherObject _żnstanceTransform;
    UI_Manager _żnstanceUIManager;
    MoveForward _żnstanceMoveForw;
    PlayerAnimation _żnstancePlayerAnimation;
    BounceBack _żnstanceBounceBack;

    private void Awake()
    {
        _żnstanceUIManager = FindObjectOfType<UI_Manager>();
        _żnstanceTransform = FindObjectOfType<TransformOtherObject>();
        _żnstanceMoveForw = FindObjectOfType<MoveForward>();
        _żnstancePlayerAnimation = FindObjectOfType<PlayerAnimation>();
        _żnstanceBounceBack = FindObjectOfType<BounceBack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="FinisLine")
        {
            //Oyun sonu bool IsGameFinish=true;
            _żnstanceMoveForw.speed = 0;
            
            _żnstanceBounceBack.veloctySpeed = 0;
            _żnstancePlayerAnimation.GetComponent<PlayerAnimation>().enabled = false;
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
            _żnstanceUIManager.controlAtmText();
            
            DestroyGameObject();



        }
        if (other.gameObject.tag == "ObstaclePendulum" || other.gameObject.tag == "ObstacleThorn")
        {
            _żnstancePlayerAnimation.AnimationControl(other);
            _żnstanceBounceBack.SetIsCollision(true);
            _żnstanceBounceBack.SetMaxPosLimit(other.gameObject.transform);

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
            _żnstanceMoveForw.speed = 0;
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
