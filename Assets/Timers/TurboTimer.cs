using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TurboTimer : Timer
{

    
    public float playerTimeAmount=60, flatAmount=60;
    private int numbPlayers;
    public TMP_Text turboChargeCount;
    // Start is called before the first frame update
    void Start()
    {
        resetTimer(); 
    }

    
    public new void resetTimer(){

        timerText.text = ((int)timerValue).ToString();  
        
    }
    
    public void changeNumbPlayers(int newPlayers){
        float previousPercentage = timerValue/timeCalculation();
        numbPlayers = newPlayers;
        timerValue = timeCalculation()*previousPercentage;

    }
    // Update is called once per frame
    void Update()
    {
        if(timerActive && timerValue > 0){
            timerValue -= Time.deltaTime;
            timerTotal += Time.deltaTime;
            if(timerValue<0){
                timerValue = 0;
                timerActive = false;
                player.charges++;
                if(player.charges < player.maxCharges){
                    startTimer();
                }
                
            }
            displayTime();
        }
    }
    public void displayTime( ){
        if(timerActive){
            timerText.enabled = true;
            timerText.text = ((int)timerValue).ToString();

        }else{
            timerText.enabled = false;
        }
        turboChargeCount.text = player.charges.ToString();
            buttonImage.fillAmount = (timeCalculation() - timerValue)/timeCalculation();
    }

    public float timeCalculation(){
        return playerTimeAmount * numbPlayers +flatAmount;
    }
    public void useTurbo(){
        player.charges-=1;
        if(timerActive){

        }else{
            startTimer();
        }
        
    }
    public void startTimer(){
        timerValue = timeCalculation();
        timerActive = true;
        timerText.text = ((int)timerValue).ToString();  

    }
    
}
