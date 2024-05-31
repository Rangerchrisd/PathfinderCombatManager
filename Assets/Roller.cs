using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Roller : MonoBehaviour
{
    public Result result;
    public Square target;
    public List<Square> allSquares = new List<Square>();
    public TMP_InputField resultNeededString;
    public int resultNeededInt(){
        string diceresultString = resultNeededString.text;
        Debug.Log(diceresultString+"");
        if(diceresultString==""){
            return 15;
        }

        return int.Parse(diceresultString);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void roll(){
        List<Square> pass = new List<Square>();
        List<Square> fail = new List<Square>();
        foreach(Square i in allSquares){
            int diceRoll = Random.Range(1,21);
            if(diceRoll == 20){
                result.displayResult(i,diceRoll+i.bonus,true, true);
                Debug.Log("crit");
            }else if(diceRoll+i.bonus>=resultNeededInt()){
                //pass
                result.displayResult(i,diceRoll+i.bonus, true, false);
                Debug.Log("pass");
            }else{
                Debug.Log("fail"); 
                result.displayResult(i,diceRoll+i.bonus,false, false);

            }
        }
    }
}
