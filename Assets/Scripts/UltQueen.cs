using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltQueen : MonoBehaviour
{
    public Health healthh;
    public Dash dash;
    public void Ult(){
        if(healthh.health < healthh.maxHealth/2) healthh.health += healthh.maxHealth/2;
        else healthh.health = healthh.maxHealth;
        healthh.hpLoss1 = 0;
        healthh.hpLoss2 = 0;
        dash.hpLoss3 = 0;
        healthh.hpLoss4 = 0;
        healthh.hpLoss5 = 0;
        healthh.hpLoss6 = 0;
        healthh.cooldown1 /= 2;
        healthh.cooldown2 /= 2;
        dash.cooldown3 /= 2;
        healthh.cooldown4 /= 2;
        healthh.cooldown5 /= 2;
        healthh.cooldown6 /= 2;
    }
}
