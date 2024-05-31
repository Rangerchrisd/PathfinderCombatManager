using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public enum rollTypes{
    none,
    attack,
    reflex,
    fortitude,
    willpower,
    cmd

}
public class Manager : MonoBehaviour
{
    public Roller roller;
    public Result result;
    public RapidShotToggle rapidShotToggle;
    public rollTypes rolltypeSelected;
    public GameObject holder, holderPreview, holderCondition;
    public GameObject squarePrefab, previewPrefab, conditionPrefab;
    public List<CharacterSheet> enemies;
    public CharacterSheet enemySelected;
    [SerializeField]
    public List<Player> players;

    public TimerManager timerManager;

    public void changeRollTypes(rollTypes rolltype){
        foreach(Square i in roller.allSquares){
            changeRollType(i, rolltype);
        }
        rolltypeSelected = rolltype;
    }

    public void changeRollType(Square i, rollTypes rolltype){
            switch(rolltype){
                case rollTypes.attack:
                    i.bonus = i.unit.attack();
                    break;
                case rollTypes.fortitude:
                    i.bonus = i.unit.fortitude();
                    break;
                case rollTypes.willpower:
                    i.bonus = i.unit.willpower();
                    break;
                case rollTypes.reflex:
                    i.bonus = i.unit.reflex();
                    break;
                case rollTypes.cmd:
                    i.bonus = i.unit.reflex();
                    break;
                default:
                    break;
            }
            i.returnToPreviousState();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    GraphicRaycaster m_Raycaster = FindObjectOfType<GraphicRaycaster>();
    EventSystem m_EventSystem= FindObjectOfType<EventSystem>();

        Square NewestSquare;
        for(int i = 0; i < 180; i++){
            NewestSquare = Instantiate(squarePrefab, holder.transform).GetComponent<Square>();
            NewestSquare.gameObject.name += i;
            NewestSquare.m_Raycaster = m_Raycaster;
            NewestSquare.m_EventSystem = m_EventSystem;

        }
        EnemyPreview NewestOne;
        for(int i = 0; i < enemies.Count;i++){
            NewestOne = Instantiate(previewPrefab, holderPreview.transform).GetComponent<EnemyPreview>();
            NewestOne.buttonImage.color = enemies[i].myColor;
            NewestOne.myEnemy = enemies[i];
            NewestOne.manager = this;
        }
        CondtionButton NewestCondition;
        
        for(int i = 0; i < typeof(Debuffs).GetEnumNames().Length -1;i++){
            NewestCondition = Instantiate(conditionPrefab, holderCondition.transform).GetComponent<CondtionButton>();
            NewestCondition.debuff = i;

        }
        switchTemplate(enemies[0]);
        changeRollTypes(rollTypes.attack);


        timerManager.InstantiateNewTimers(players);
    }
    public void switchTemplate(CharacterSheet newEnemy){
        enemySelected = newEnemy;
    }
    void clearResults(){
        result.clearResults();
    }
    public void DropdownValueChanged(TMP_Dropdown change)
    {
        switch(change.value){
            case 0:
                rolltypeSelected = rollTypes.attack;
                break;
            case 1:
                rolltypeSelected = rollTypes.reflex;
                break;
            case 2:
                rolltypeSelected = rollTypes.fortitude;
                break;
            case 3:
                rolltypeSelected = rollTypes.willpower;
                break;
            case 4:
                rolltypeSelected = rollTypes.cmd;
                break;
            default:
                break;
        }
        changeRollTypes(rolltypeSelected);
    }
}