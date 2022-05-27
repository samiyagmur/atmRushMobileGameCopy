using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "ObstaclePendulum")
        {
            Debug.Log("girdi");
            gameObject.GetComponent<Animator>().SetBool("IsFalling", true);
            gameObject.GetComponent<Animator>().SetBool("IsStanding", true);
            gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
            //speed = 0;
        }
    }
}
