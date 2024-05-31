using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    
    public float baseAmount=60, addAmount=60;
    [SerializeField]
    protected float timerValue = 0, timerTotal = 0;
    protected bool timerActive = false;
    public TMP_Text timerText;
    public Image buttonImage;
    public Color myColor;
    public Player player;
    public GameObject TimerParent;
    public TurboTimer turboTimer;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage.color = myColor;
        turboTimer.player = player;
        resetTimer(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timerActive && timerValue > 0){
            timerValue -= Time.deltaTime;
            timerTotal += Time.deltaTime;
            if(timerValue<0){
                timerValue = 0;
                timerActive = false;
            }
            timerText.text = ((int)timerValue).ToString();
        }
    }
    public void toggleTimer(){
        timerActive = !timerActive;

    }
    public void resetTimer(){

        timerValue = baseAmount;
        timerText.text = ((int)timerValue).ToString();  
        
    }
    public float getTimer(){

        return timerValue;
        
    }
    
    public float getTimerTotal(){

        return timerTotal;
        
    }
    
    public void setTimerTotal(float newTotalTime){

        timerTotal = newTotalTime;
        
    }
    public void addTimer(){

        timerValue += addAmount;
    }
}
