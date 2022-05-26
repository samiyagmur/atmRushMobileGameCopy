using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private int count = -1;
    [SerializeField] Text AtmText;
   
    // Start is called before the first frame update
    

    public void controlAtmText(GameObject atm)
    {   
        Debug.Log(count);
        count++;
        AtmText.text = count.ToString();

        if (atm.tag!="Player")
        {
            Destroy(atm);
        }
       

    }
}
