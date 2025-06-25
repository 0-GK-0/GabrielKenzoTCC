using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltQueen : MonoBehaviour
{
    public Health healthh;
    public Atks atks;
    public void Ult(){
        if(healthh.health < healthh.maxHealth/2) healthh.health += healthh.maxHealth/2;
        else healthh.health = healthh.maxHealth;
        atks.hpLoss1 = 0;
        atks.hpLoss2 = 0;
        atks.hpLoss3 = 0;
        atks.hpLoss4 = 0;
        atks.hpLoss5 = 0;
        atks.hpLoss6 = 0;
        atks.cooldown1 /= 2;
        atks.cooldown2 /= 2;
        atks.cooldown3 /= 2;
        atks.cooldown4 /= 2;
        atks.cooldown5 /= 2;
        atks.cooldown6 /= 2;
    }
}
