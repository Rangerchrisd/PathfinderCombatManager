using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RapidShotToggle : MonoBehaviour
{
    public TMP_Text toggleText;
    public Manager manager;
    public bool toggled = false;

    public void toggleAttack(){
        if(toggled){
            toggled= false;
            toggleText.text="";
        }else{
            toggled= true;
            toggleText.text="X";
        }
        manager.changeRollTypes(manager.rolltypeSelected);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
