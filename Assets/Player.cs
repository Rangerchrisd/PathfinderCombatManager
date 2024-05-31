using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public Color myColor;
    public string playerName;
    public float playerTime;
    public Timer timer;
    public int maxCharges, charges;
    public bool IsActive;

    public void toggleTimer(){
        timer.gameObject.SetActive(!IsActive);

    }

}
