using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    public List<Timer> timers;
    public float timeValue;
    public TMP_Text partyTimerText;
    public Transform timerParentTransform;
    public GameObject timerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void saveTimes(){
        StreamWriter stream;
        string path;// = "Assets/Resources/test.txt";
        foreach(Timer i in timers){
            path = "Assets/Saves/"+ i.player.playerName + ".txt";
            File.WriteAllText(path, "");
            stream = new StreamWriter(path,true);
            stream.Write(i.getTimerTotal().ToString());
            stream.Flush();
            stream.Close();
        }

    }
    public void loadTimes(){
        StreamReader stream;
        string path;// = "Assets/Resources/test.txt";
        foreach(Timer i in timers){
            path = "Assets/Saves/"+ i.player.playerName + ".txt";
            stream = new StreamReader(path,true);
            i.setTimerTotal(float.Parse(stream.ReadLine()));
            stream.Close();
        }

    }
    public void InstantiateNewTimers(List<Player> players){
        foreach(Player i in players){
            Timer newTimer = Instantiate(timerPrefab, timerParentTransform).GetComponent<Timer>();
            newTimer.myColor = i.myColor;
            newTimer.setTimerTotal(i.playerTime);
            timers.Add(newTimer);
            newTimer.player = i;
            
        }
        loadTimes();
    }

    // Update is called once per frame
    void Update()
    {
        float timeValueNew = 0;
        foreach(Timer i in timers){
            timeValueNew += i.getTimerTotal();
        }
            partyTimerText.text = ((int)timeValueNew).ToString();
            timeValue = timeValueNew;
    }

    public void OnApplicationQuit() {
        
        foreach(Timer i in timers){
            Debug.Log(i.player.playerName +"Total Time: " + i.getTimerTotal().ToString());
            Debug.Log(i.player.playerName +"Turbo Time Left " + i.turboTimer.getTimerTotal().ToString());
            //timeValueNew += i.getTimerTotal();
        }
        saveTimes();
        Debug.Log("Total: " + timeValue);
    }
    public void toggleTimer(Player player){

    }
}
