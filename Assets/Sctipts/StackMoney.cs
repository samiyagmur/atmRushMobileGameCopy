using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StackMoney : MonoBehaviour
{
    public static StackMoney _insatance;
    public float movementDelay=0.25f;

    public List<GameObject> _stacts = new List<GameObject>();

    private void Awake()
    {
        if (_insatance = null)
        {
            _insatance = this;
        }
    }

    
   



}
