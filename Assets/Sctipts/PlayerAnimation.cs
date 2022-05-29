using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    BounceBack _żnstanceBounceBack;

    private void Awake()
    {
            _żnstanceBounceBack=GetComponent<BounceBack>();
    }
    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "ObstaclePendulum" || gameObject.tag == "ObstacleThorn")
        {
            Debug.Log("girdi");
            gameObject.GetComponent<Animator>().SetBool("IsFalling", true);
            gameObject.GetComponent<Animator>().SetBool("IsStanding", true);
            gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
            //speed = 0;
            _żnstanceBounceBack.SetIsCollision(true);
            _żnstanceBounceBack.SetMaxPosLimit(other.gameObject.transform);

        }
    }
}
