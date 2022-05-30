using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyCollision : MonoBehaviour
{
    TransformOtherObject _�nstanceTransform;
    UI_Manager _�nstanceUIManager;
    MoveForward _�nstanceMoveForw;
    PlayerAnimation _�nstancePlayerAnimation;
    BounceBack _�nstanceBounceBack;

    private void Awake()
    {
        _�nstanceUIManager = FindObjectOfType<UI_Manager>();
        _�nstanceTransform = FindObjectOfType<TransformOtherObject>();
        _�nstanceMoveForw = FindObjectOfType<MoveForward>();
        _�nstancePlayerAnimation = FindObjectOfType<PlayerAnimation>();
        _�nstanceBounceBack = FindObjectOfType<BounceBack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="FinisLine")
        {
            //Oyun sonu bool IsGameFinish=true;
            _�nstanceMoveForw.speed = 0;
            
            _�nstanceBounceBack.veloctySpeed = 0;
            _�nstancePlayerAnimation.GetComponent<PlayerAnimation>().enabled = false;
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
            _�nstanceUIManager.controlAtmText();
            
            DestroyGameObject();



        }
        if (other.gameObject.tag == "ObstaclePendulum" || other.gameObject.tag == "ObstacleThorn")
        {
            _�nstancePlayerAnimation.AnimationControl(other);
            _�nstanceBounceBack.SetIsCollision(true);
            _�nstanceBounceBack.SetMaxPosLimit(other.gameObject.transform);

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
            _�nstanceMoveForw.speed = 0;
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
