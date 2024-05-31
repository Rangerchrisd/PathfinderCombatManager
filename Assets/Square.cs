using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class Square : MonoBehaviour, IPointerClickHandler, IDragHandler,  IEndDragHandler, IBeginDragHandler
{
    public int bonus = 0;
    Vector3 originalPosition;
    public InstanceUnit unit = null;
    public bool selected = false;
    public Image image;
    public TMP_Text descriptiveText, conditionText;
        public Manager manager;
    
    public Color NoUnit, passedTest, failedTest, critTest;
    // Start is called before the first frame update
    void Start()
    {
        image.color = Color.black;
        if(!manager){
            manager = FindObjectOfType<Manager>();
        }
    }
    public void returnToPreviousState(){
        if(unit!=null){
            image.color = unit.myColor;
            descriptiveText.color = Color.white;
            descriptiveText.text = ""+bonus;
            conditionText.text = "";
            foreach(Debuffs i in unit.debuffs){
                switch(i){
                    case Debuffs.entangled:
                        conditionText.text += "E";
                        break;
                    case Debuffs.stagger:
                        conditionText.text += "S";
                        break;
                    case Debuffs.fired:
                        conditionText.text += "Fi";
                        break;
                    case Debuffs.blind:
                        conditionText.text += "B";
                        break;
                    case Debuffs.grappled:
                        conditionText.text += "G";
                        break;
                    default:
                        Debug.Log(" fell through");
                        break;
                }
            }
        }else{
            image.color = NoUnit;
            descriptiveText.text = "";

        }
    }
    public void toggleDebuff(int debuff){
        if(unit!=null){
            unit.toggleDebuff((Debuffs)debuff);
            returnToPreviousState();
            manager.changeRollType(this,manager.rolltypeSelected);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left){
            if (unit!=null){
                removeUnit();
            }
            else{
                addUnit();
            }
        }
    }

    public void addUnit(){

        unit = new InstanceUnit(manager.enemySelected);
        unit.manager = manager;
        image.color = manager.enemySelected.myColor;
        manager.changeRollType(this, manager.rolltypeSelected);
        descriptiveText.text = ""+bonus;
        manager.roller.allSquares.Add(this);
        returnToPreviousState();
    }
    
    public void addUnit(InstanceUnit instance){

        unit = instance;
        image.color = instance.myColor;
        manager.changeRollType(this, manager.rolltypeSelected);
        descriptiveText.text = ""+bonus;
        manager.roller.allSquares.Add(this);
        returnToPreviousState();
    }
    public void removeUnit(){
        manager.roller.allSquares.Remove(this);
        unit = null;
        image.color = NoUnit;
        descriptiveText.text = "";
        returnToPreviousState();
    }
    public void moveUnit(Square previousLocation){

        if(unit == null){
            if(previousLocation.unit != null){
                addUnit(previousLocation.unit);
                previousLocation.removeUnit();
            }
        }

    }


    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        
        if(unit != null){
            transform.localPosition = originalPosition;
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //EventSystem.current.RaycastAll()
            if(results.Count > 0){
                Square square = results[0].gameObject.GetComponent<Square>();
                if(square){
                    square.moveUnit(this);
                }
            }
        image.raycastTarget = true;
        }
    }
    
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(unit != null){
            transform.position = Input.mousePosition; 
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(unit != null){
            updateCorrectLocation();
            image.raycastTarget = false;
        }
    }
public void updateCorrectLocation(){
        originalPosition = transform.localPosition;
}
}
