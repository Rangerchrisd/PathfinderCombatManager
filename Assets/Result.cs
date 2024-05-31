using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public List<Square> squaresWithResults; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void displayResult(Square square, int Result, bool pass, bool crit){
        square.descriptiveText.text = ""+Result+"!";
        if(crit){
            //square.descriptiveText.color = square.critTest;
            square.descriptiveText.text = ""+Result+"<color=yellow>!</color>";
        }else if(pass){
            //square.descriptiveText.color = square.passedTest;
            square.descriptiveText.text = ""+Result+"<color=green>!</color>";
        }else if(!pass){
            //square.descriptiveText.color = square.failedTest;
            square.descriptiveText.text = ""+Result+"<color=#ff0000ff>!</color>";
        }
        squaresWithResults.Add(square);
    }
    public void clearResults(){
        
                foreach(Square i in squaresWithResults){
                    i.returnToPreviousState();
                }
                squaresWithResults.Clear();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
