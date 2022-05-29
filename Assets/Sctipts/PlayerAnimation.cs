using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    BounceBack _�nstanceBounceBack;

    private void Awake()
    {
            _�nstanceBounceBack=GetComponent<BounceBack>();
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
            _�nstanceBounceBack.SetIsCollision(true);
            _�nstanceBounceBack.SetMaxPosLimit(other.gameObject.transform);

        }
    }
}
