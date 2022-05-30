using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private int countBehind;
    private int countAtm=-1;
    [SerializeField] Text AtmText;
    [SerializeField] Text PlayerBehindText;

   

    // Start is called before the first frame update


    public void controlAtmText()
    {
        countAtm++;
        AtmText.text = countAtm.ToString();
    }
    private void FixedUpdate()
    {

        countBehind = StackMoney._instance._moneyStack.Count-1;

        countBehind = countBehind - countAtm;
        Debug.Log(countBehind);
        PlayerBehindText.text = countBehind.ToString();



    }
}