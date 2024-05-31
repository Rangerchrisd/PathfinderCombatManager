using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class CondtionButton : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    public int debuff;
    Vector3 originalPosition;
    public Image image;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    public TMP_Text conditionText;
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
     transform.position = Input.mousePosition; 
    }


    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
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
                    square.toggleDebuff(debuff);
                }
            }
        image.raycastTarget = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Raycaster = FindObjectOfType<GraphicRaycaster>();
        m_EventSystem = FindObjectOfType<EventSystem>();
        Debuffs debuffEnumVal = (Debuffs)debuff;
        conditionText.text = debuffEnumVal.ToString();//nameof(debuffEnumVal.ToString() );
    }
public void updateCorrectLocation(){
        originalPosition = transform.localPosition;
}
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        updateCorrectLocation();
        image.raycastTarget = false;

    }
}

