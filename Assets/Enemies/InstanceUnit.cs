using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Debuffs{
    none = -1,
    entangled = 0,
    fired = 1,
    stagger = 2,
    blind = 3,
    grappled 
}
public class InstanceUnit
{
    public List<Debuffs> debuffs;
    public Manager manager;

    public void toggleDebuff(Debuffs debuff){
        if(debuffs.Contains(debuff)){
            debuffs.Remove(debuff);
            switch(debuff){
                case Debuffs.entangled:
                    MODattack += 2;
                    MODdexterity += 4;
                    break;
                case Debuffs.stagger:
                    break;
                case Debuffs.fired:
                    break;
                case Debuffs.blind:
                    break;
                default:
                    break;
            }
        }else{
            debuffs.Add(debuff);
            switch(debuff){
                case Debuffs.entangled:
                    MODattack -= 2;
                    MODdexterity -= 4;
                    break;
                case Debuffs.stagger:
                    break;
                case Debuffs.fired:
                    break;
                case Debuffs.blind:

                    break;
                default:
                    break;
            }
        }
    }

    public InstanceUnit(CharacterSheet character){
        load(character);
        debuffs = new List<Debuffs>();
    }
    public void load(CharacterSheet characterSheet){
        baseAttack = characterSheet.baseAttack;
        basecharisma = characterSheet.basecharisma;
        basewisdom = characterSheet.basewisdom;
        baseWillpower = characterSheet.baseWillpower;
        baseconstitution = characterSheet.baseconstitution;
        baseFortitude = characterSheet.baseFortitude;
        basestrength = characterSheet.basestrength;
        basedexterity = characterSheet.basedexterity;
        myColor = characterSheet.myColor;
        myName = characterSheet.myName;
        dexToHit = characterSheet.dexToHit;
        canRapidShot = characterSheet.canRapidShot;
    }
        public bool dexToHit, canRapidShot;
    public Color myColor;
    public string myName;
    public int getDexterity(){
        return MODdexterity + basedexterity;
    }
    public int getIntelligence(){
        return MODintelligence + baseintelligence;
    }
    public int getConstitution(){
        return MODconstitution + baseconstitution;
    }
    public int getCharisma(){
        return MODcharisma + basecharisma;
    }
    public int getWisdom(){
        return MODwisdom + basewisdom;
    }
    public int getStrength(){
        return MODstrength + basestrength;
    }
    public int MODstrength, MODdexterity, MODintelligence, MODwisdom, MODcharisma, MODconstitution, MODattack;
    public int basestrength, basedexterity, baseintelligence, basewisdom, basecharisma, baseconstitution;
    public int returnMod(int abilityScore){
        return (abilityScore-10)/2;
    }
    public int baseAttack, baseFortitude, baseWillpower, baseReflex;
    public int reflex(){
        return returnMod(getDexterity())+baseReflex;
    }
    public int fortitude(){
        return returnMod(getConstitution())+baseFortitude;
    }
    public int willpower(){
        return returnMod(getWisdom())+baseWillpower;
    }
    public int attack(){
        int AbilityMod = 0;
        if(dexToHit){
            AbilityMod = returnMod(getDexterity());
        }else{
            AbilityMod = returnMod(getStrength());
        }
        if(manager.rapidShotToggle.toggled&&canRapidShot)
            return AbilityMod + baseAttack +MODattack - 2;

        return AbilityMod + baseAttack +MODattack;
    }
}
