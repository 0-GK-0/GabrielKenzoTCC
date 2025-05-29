using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Values")]
    public int health;
    public int maxHealth;
    public Image healthBar;

    private void Start(){
        health = maxHealth;
    }
    public void Dmg(int dmg){
        health -= dmg;
        healthBar.fillAmount = health / 100;
        Debug.Log($"{health},{gameObject}");
    }
}
