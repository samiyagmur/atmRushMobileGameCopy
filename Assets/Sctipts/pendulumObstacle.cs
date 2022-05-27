using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pendulumObstacle : MonoBehaviour
{
    public Ease easy;

    private void Start()//TODO: öðrenilecek
    {
       // transform.DORotate(new Vector3(0, 0, -90), 2, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetEase(easy);
    }
}
