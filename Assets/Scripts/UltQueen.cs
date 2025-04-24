using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltQueen : MonoBehaviour
{
    public Atks atks;
    public Dash dash;
    public void Ult(){
        if(atks.health < maxHealth/2) health += maxHealth/2;
        else health = maxHealth;
        atks.hpLoss1 = 0;
        atks.hpLoss2 = 0;
        dash.hpLoss3 = 0;
        atks.hpLoss4 = 0;
        atks.hpLoss5 = 0;
        atks.hpLoss6 = 0;
        atks.cooldown1 /= 2;
        atks.cooldown2 /= 2;
        dash.cooldown3 /= 2;
        atks.cooldown4 /= 2;
        atks.cooldown5 /= 2;
        atks.cooldown6 /= 2;
    }
}
