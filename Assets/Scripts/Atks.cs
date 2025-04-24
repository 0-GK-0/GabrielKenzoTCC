using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AtkType { one, two, three, four, five, six }
public class Atks : MonoBehaviour
{
    [Header("Values")]
    public int health;
    public int maxHealth;
    public float currentCooldown;
    public LayerMask canHit;
    private float damageToReceive;
    private int damageReceived;
    public Transform atkPoint;
    public Transform projCreationPoint;
    public Transform orientation;
    public Transform player;

    [Header("Attack1 - Melee")]
    public int dmg1;
    public int range1;
    public int hpLoss1;
    public float cooldown1;
    public KeyCode attack1;

    [Header("Attack2 - Melee")]
    public int dmg2;
    public int range2;
    public int hpLoss2;
    public float cooldown2;
    public KeyCode attack2;

    [Header("Attack3 - Melee")]
    public int dmg3;
    public int range3;
    public int hpLoss3;
    public float cooldown3;
    public KeyCode attack3;

    [Header("Attack4 - Range")]
    public int hpLoss4;
    public float cooldown4;
    public KeyCode attack4;
    public GameObject projectile4;

    [Header("Attack5 - Range")]
    public int hpLoss5;
    public float cooldown5;
    public KeyCode attack5;
    public GameObject projectile5;

    [Header("Attack6 - Range")]
    public int hpLoss6;
    public float cooldown6;
    public KeyCode attack6;
    public GameObject projectile6;

    private void Start(){
        health = maxHealth;
    }
    private void Update(){
        GetAttack();
        if(currentCooldown > 0) currentCooldown -= Time.deltaTime;
    }

    private void GetAttack(){
        if(currentCooldown > 0) return;
        if(Input.GetKeyDown(attack1)) MeleeAttack(AtkType.one);
        if(Input.GetKeyDown(attack2)) MeleeAttack(AtkType.two);
        if(Input.GetKeyDown(attack3)) MeleeAttack(AtkType.three);
        if(Input.GetKeyDown(attack4)) RangedAtk(AtkType.four);
        if(Input.GetKeyDown(attack5)) RangedAtk(AtkType.five);
        if(Input.GetKeyDown(attack6)) RangedAtk(AtkType.six);
    }

    private void MeleeAttack(AtkType type){
        int atkDmg = type switch
        {
            AtkType.one => dmg1,
            AtkType.two => dmg2,
            AtkType.three => dmg3,
            _ => 0
        };
        float range = type switch
        {
            AtkType.one => range1,
            AtkType.two => range2,
            AtkType.three => range3,
            _ => 0f
        };
        float hpLoss = type switch
        {
            AtkType.one => hpLoss1,
            AtkType.two => hpLoss2,
            AtkType.three => hpLoss3,
            _ => 0f
        };
        float cooldown = type switch
        {
            AtkType.one => cooldown1,
            AtkType.two => cooldown2,
            AtkType.three => cooldown3,
            _ => 0f
        };

        Collider[] hit = Physics.OverlapSphere(atkPoint.position, range, canHit);
        foreach (Collider enemy in hit)
        {
            enemy.GetComponent<Atks>().Dmg(atkDmg);
        }
        if(health>1)DamagePercentage(hpLoss);
        currentCooldown = cooldown;
    }

    private void RangedAtk(AtkType type){
        float hpLossRanged = type switch
        {
            AtkType.four => hpLoss4,
            AtkType.five => hpLoss5,
            AtkType.six => hpLoss6,
            _ => 0f
        };
        float cooldownRanged = type switch
        {
            AtkType.four => cooldown4,
            AtkType.five => cooldown5,
            AtkType.six => cooldown6,
            _ => 0f
        };
        GameObject projectile = type switch
        {
            AtkType.four => projectile4,
            AtkType.five => projectile5,
            AtkType.six => projectile6,
            _ => null
        };

        if(health>1)DamagePercentage(hpLossRanged);
        CreateProjectile(projectile);
        currentCooldown = cooldownRanged;
    }
    public void DamagePercentage(float damagePercentage){
        damageToReceive = Mathf.Ceil(damagePercentage/100 * health);
        damageReceived = (int)damageToReceive;
        Dmg(damageReceived);
        Debug.Log(health);
    }
    
    public void Dmg(int dmg){
        health -= dmg;
    }
    private void CreateProjectile(GameObject projectilee){
        Instantiate(projectilee, projCreationPoint.position, orientation.rotation);
    }
}
