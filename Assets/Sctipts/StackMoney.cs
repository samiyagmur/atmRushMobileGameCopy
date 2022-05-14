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
        
        if (_insatance == null)
        {
            _insatance = this;
        }
    }

    private void Update()
    {
        transform.parent = transform;
        if (Input.GetButton("Fire1"))
        {
            FollowListObject();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            MOveOrigin();
        }
    }


    public void StackMoneys(GameObject _stackAbleOtherObject, int index)
    {   

        _stackAbleOtherObject.transform.parent = transform;
        
        Debug.Log(transform.position.y);
        Vector3 newPos= _stacts[index].transform.localPosition;
        newPos.z += 0.5f;
        _stackAbleOtherObject.transform.localPosition = newPos;
        StartCoroutine(_staclAbleOtherObjectCanBigger());
        _stacts.Add(_stackAbleOtherObject);
        

    }

    private IEnumerator _staclAbleOtherObjectCanBigger()
    {
        for (int i = _stacts.Count-1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1,1,1);
            scale *= 1.2f;

            _stacts[index].transform.DOScale(scale, 0.1f).OnComplete(()=>
            _stacts[index].transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f),0.1f));
            yield return new WaitForSeconds(0.05f);

        }

        
    }

    public void FollowListObject()
    {
        for (int i = 1; i < _stacts.Count; i++)
        {
            Vector3 pos = _stacts[i].transform.localPosition;
            pos.x=_stacts[i-1].transform.localPosition.x;
            _stacts[i].transform.DOLocalMove(pos, movementDelay);


        }
    }

    public void MOveOrigin()
    {
        for (int i = 1; i < _stacts.Count; i++)
        {
            Vector3 pos = _stacts[i].transform.localPosition;
            pos.x = _stacts[0].transform.localPosition.x;
            _stacts[i].transform.DOLocalMove(pos, movementDelay);


        }
    }

   



}
//if (other.gameObject.CompareTag("Money"))
//{

//    ////new Vector3(0, 0, transform.localScale.z);
//    //other.gameObject.transform.position = transform.position + Vector3.forward;

//    ////Destroy(gameObject.GetComponent<StockMoney>());
//    //other.gameObject.AddComponent<StockMoney>();
//    //other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
//    ////other.gameObject.GetComponent<Rigidbody>().constraints;
//    //other.gameObject.AddComponent<MoneyMovement>();
//    //other.gameObject.GetComponent<MoneyMovement>().connectedNode = transform;
//    //other.gameObject.tag = "OldMoney";




//}