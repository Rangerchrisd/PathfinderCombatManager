using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [CreateAssetMenu(
        fileName = "CharacterSheets",
        menuName = "Scriptable Objects/CharacterSheet")]
public class CharacterSheet : ScriptableObject
{
    public bool dexToHit, canRapidShot;
    public Color myColor;
    public string myName;
    public int basestrength, basedexterity, baseintelligence, basewisdom, basecharisma, baseconstitution;
    public int baseAttack, baseFortitude, baseWillpower, baseReflex;
}
