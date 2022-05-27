using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    //[SerializeField] Animator bumpToObject;
    //private bool standingPosition;
    //private bool fallingPosition;
    void Start()
    {
        //bumpToObject = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="box")
        {
            Debug.Log("girdi");
            gameObject.GetComponent<Animator>().SetBool("IsFalling", true);
        }
    }

    //private bool ÝsCollisinonEnter()
    //{
    //    return true;
    //}
}
