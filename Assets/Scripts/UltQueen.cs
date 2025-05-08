using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltQueen : MonoBehaviour
{
    public Atks atks;
    public Dash dash;
    public void Ult(){
        if(atks.health < atks.maxHealth/2) atks.health += atks.maxHealth/2;
        else atks.health = atks.maxHealth;
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
