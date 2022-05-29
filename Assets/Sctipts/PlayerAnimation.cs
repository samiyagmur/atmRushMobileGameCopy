using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (gameObject.tag == "ObstaclePendulum" || gameObject.tag == "ObstacleThorn")
    //    {
            


            
    //    }
    //}

    public void AnimationControl(Collider other)
    {
       
        gameObject.GetComponent<Animator>().SetBool("IsFalling", true);
        gameObject.GetComponent<Animator>().SetBool("IsStanding", true);
        gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
        //speed = 0;
        
    }
}
