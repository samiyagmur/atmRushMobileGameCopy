using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator bumpToObject;
    void Start()
    {
        bumpToObject = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (�sCollisinonEnter())
        {
            
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        �sCollisinonEnter();
    }

    private bool �sCollisinonEnter()
    {
        return true;
    }
}
