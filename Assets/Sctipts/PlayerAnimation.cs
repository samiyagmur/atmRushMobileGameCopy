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
        if (ÝsCollisinonEnter())
        {
            
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        ÝsCollisinonEnter();
    }

    private bool ÝsCollisinonEnter()
    {
        return true;
    }
}
