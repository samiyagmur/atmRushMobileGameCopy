using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StackMoney : MonoBehaviour
{
    public static StackMoney _instance;
    public List<GameObject> _moneyStack=new List<GameObject>();

    public float movementDelay=0.25f;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }


    public void StackMoneys(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = _moneyStack[index].transform.localPosition;
        newPos.z += 0.5f;
        other.transform.localPosition = newPos;
        StartCoroutine(MakeObjectsBigger());
    }

    private IEnumerator MakeObjectsBigger()
    {
        for (int i = _moneyStack.Count-1; i > 0; i--)
        {
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;

            _moneyStack[i].transform.DOScale(scale, 0.1f).OnComplete(() =>
            _moneyStack[i].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return null; new WaitForSeconds(0.05f);

        }
    }

    public void MoveListElements()
    {
        for (int i = 0; i < _moneyStack.Count; i++)
        {
            Vector3 pos = _moneyStack[i].transform.localPosition;
            pos.x = _moneyStack[i - 1].transform.localPosition.x;
            _moneyStack[i].transform.DOLocalMove(pos,movementDelay);
        }
    }
    public void MoveOrigin()
    {
        for (int i = 0; i < _moneyStack.Count; i++)
        {
            Vector3 pos = _moneyStack[i].transform.localPosition;
            pos.x = _moneyStack[0].transform.localPosition.x;
            _moneyStack[i].transform.DOLocalMove(pos, 0.70f);
        }
    }

}
