using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPreview : MonoBehaviour
{
    public Image buttonImage;
    public CharacterSheet myEnemy;
    public Manager manager;
    public void selectMe(){
        manager.switchTemplate(myEnemy);

    }
}
