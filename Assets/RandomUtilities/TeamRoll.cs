using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamRoll : MonoBehaviour
{
    public List<string> playerNames;
    public int numberOfBlanks;
    // Start is called before the first frame update
    void Start()
    {
        MakeTeams();
    }
    public bool runTest;

    void Update() {
        if(runTest){
            MakeTeams();
            runTest = false;
        }
    }



    void MakeTeams()
    {
        UnityEngine.Random.InitState(1234);
         List<string> playerNamesDeep = new List<string>(playerNames);
        List<string> playing = new List<string>();
        for(int i= 0; i< numberOfBlanks;i++){
            playing.Add("blank");
        }
        
        for(int i= numberOfBlanks; i< playerNames.Count;i++){
            string pulled = playerNamesDeep[Random.Range(0,playerNames.Count)];
            playerNamesDeep.Remove(pulled);
            playing.Add(pulled);
        }
            playing = Randomize(playing);
            bool inOrder = true, good = true;
            while(inOrder){
                for(int i= 0; i < playerNames.Count;i++){
                    if(playerNames[i]==playing[i])
                        good = false;
                }
                inOrder = !good;
            }
        for(int i= 0; i < playerNames.Count;i++){
            if(playerNames[i]==playing[i])
                Debug.Log(playerNames[i]+ " is teamed up with" +playing[i]);
        }
    }


    public static List<T> Randomize<T>(List<T> list)
    {
        List<T> randomizedList = new List<T>();
        System.Random rnd = new System.Random();
        while (list.Count > 0)
        {
            int index = rnd.Next(0, list.Count); //pick a random item from the master list
            randomizedList.Add(list[index]); //place it at the end of the randomized list
            list.RemoveAt(index);
        }
        return randomizedList;
    }


}
