using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AtkType { one, two, three, four, five, six, onetwo, onethree, onefour, onefive, onesix, twothree, twofour, twofive, twosix, fourfive, foursix, fivesix }
public class Atks : MonoBehaviour
{
    [Header("Values")]
    public float currentCooldown;
    public LayerMask canHit;
    private float damageToReceive;
    private int damageReceived;
    public Transform atkPoint;
    public Transform projCreationPoint;
    public Transform orientation;
    public Transform player;
    public float timeForSecondKey;
    public float maxTimeForSecondKey = 0.05f;
    public bool pressed1 = false;
    public bool pressed2 = false;
    public bool pressed3 = false;
    public bool pressed4 = false;
    public bool pressed5 = false;
    public bool pressed6 = false;
    public bool hasPressed = false;
    [SerializeField] private Health healthh;
    [SerializeField] private PlayerMovv playerMov;
    [SerializeField] private Dash dash;
    [SerializeField] private Transform otherPlayerTransform;

    [Header("Attack1 - Melee")]
    public int hpLoss1;
    public float cooldown1;
    public KeyCode attack1;
    public GameObject projectile1;
    public bool rotateProj1;
    public bool selfCreate1;

    [Header("Attack2 - Melee")]
    public int hpLoss2;
    public float cooldown2;
    public KeyCode attack2;
    public GameObject projectile2;
    public bool rotateProj2;
    public bool selfCreate2;

    [Header("Attack3 - Movement")]
    public int dmg3;
    public int hpLoss3;
    public float cooldown3;
    public KeyCode attack3;
    public GameObject dashCollider;
    public bool selfCreate3;

    [Header("Attack4 - Range")]
    public int hpLoss4;
    public float cooldown4;
    public KeyCode attack4;
    public GameObject projectile4;
    public bool rotateProj4;
    public bool selfCreate4;

    [Header("Attack5 - Range")]
    public int hpLoss5;
    public float cooldown5;
    public KeyCode attack5;
    public GameObject projectile5;
    public bool rotateProj5;
    public bool selfCreate5;

    [Header("Attack6 - Range")]
    public int hpLoss6;
    public float cooldown6;
    public KeyCode attack6;
    public GameObject projectile6;
    public bool rotateProj6;
    public bool selfCreate6;

    [Header("Attack7 - Combination 1 2")]
    public int hpLoss7;
    public float cooldown7;
    public GameObject projectile7;
    public bool rotateProj7;
    public bool selfCreate7;

    [Header("Attack8 - Combination 1 3")]
    public int hpLoss8;
    public float cooldown8;
    public GameObject projectile8;
    public bool rotateProj8;
    public bool selfCreate8;

    [Header("Attack9 - Combination 1 4")]
    public int hpLoss9;
    public float cooldown9;
    public GameObject projectile9;
    public bool rotateProj9;
    public bool selfCreate9;

    [Header("Attack10 - Combination 1 5")]
    public int hpLoss10;
    public float cooldown10;
    public GameObject projectile10;
    public bool rotateProj10;
    public bool selfCreate10;

    [Header("Attack11 - Combination 1 6")]
    public int hpLoss11;
    public float cooldown11;
    public GameObject projectile11;
    public bool rotateProj11;
    public bool selfCreate11;

    [Header("Attack12 - Combination 2 3")]
    public int hpLoss12;
    public float cooldown12;
    public GameObject projectile12;
    public bool rotateProj12;
    public bool selfCreate12;

    [Header("Attack13 - Combination 2 4")]
    public int hpLoss13;
    public float cooldown13;
    public GameObject projectile13;
    public bool rotateProj13;
    public bool selfCreate13;

    [Header("Attack14 - Combination 2 5")]
    public int hpLoss14;
    public float cooldown14;
    public GameObject projectile14;
    public bool rotateProj14;
    public bool selfCreate14;

    [Header("Attack15 - Combination 2 6")]
    public int hpLoss15;
    public float cooldown15;
    public GameObject projectile15;
    public bool rotateProj15;
    public bool selfCreate15;

    [Header("Attack16 - Combination 4 5")]
    public int hpLoss16;
    public float cooldown16;
    public GameObject projectile16;
    public bool rotateProj16;
    public bool selfCreate16;

    [Header("Attack17 - Combination 4 6")]
    public int hpLoss17;
    public float cooldown17;
    public GameObject projectile17;
    public bool rotateProj17;
    public bool selfCreate17;

    [Header("Attack18 - Combination 5 6")]
    public int hpLoss18;
    public float cooldown18;
    public GameObject projectile18;
    public bool rotateProj18;
    public bool selfCreate18;

    private void Update()
    {
        GetAttack();
        if (currentCooldown > 0) currentCooldown -= Time.deltaTime;
        if (hasPressed = true && timeForSecondKey > 0) timeForSecondKey -= Time.deltaTime;
        else if (timeForSecondKey < 0)
        {
            timeForSecondKey = 0;
            StartCoroutine(atkCoroutine());
        }
    }

    private void GetAttack()
    {
        if (Input.GetKeyDown(KeyCode.T)) StartCoroutine(atkCoroutine());
        if (currentCooldown > 0) return;
        if (!playerMov.canInput) return;
        if (Input.GetKeyDown(attack1))
        {
            if (!hasPressed) timeForSecondKey = maxTimeForSecondKey;
            pressed1 = true;
            hasPressed = true;
        }
        if (Input.GetKeyDown(attack2))
        {
            if (!hasPressed) timeForSecondKey = maxTimeForSecondKey;
            pressed2 = true;
            hasPressed = true;
        }
        if (Input.GetKeyDown(attack3))
        {
            if (!hasPressed) timeForSecondKey = maxTimeForSecondKey;
            pressed3 = true;
            hasPressed = true;
        }
        if (Input.GetKeyDown(attack4))
        {
            if (!hasPressed) timeForSecondKey = maxTimeForSecondKey;
            pressed4 = true;
            hasPressed = true;
        }
        if (Input.GetKeyDown(attack5))
        {
            if (!hasPressed) timeForSecondKey = maxTimeForSecondKey;
            pressed5 = true;
            hasPressed = true;
        }
        if (Input.GetKeyDown(attack6))
        {
            if (!hasPressed) timeForSecondKey = maxTimeForSecondKey;
            pressed6 = true;
            hasPressed = true;
        }

        if (hasPressed)
        {
            if (pressed1)
            {
                if (pressed2) RangedAtk(AtkType.onetwo);
                else if (pressed4) RangedAtk(AtkType.onefour);
                else if (pressed5) RangedAtk(AtkType.onefive);
                else if (pressed6) RangedAtk(AtkType.onesix);
                else if (timeForSecondKey <= 0) RangedAtk(AtkType.one);
            }
            else if (pressed2)
            {
                if (pressed4) RangedAtk(AtkType.twofour);
                else if (pressed5) RangedAtk(AtkType.twofive);
                else if (pressed6) RangedAtk(AtkType.twosix);
                else if (timeForSecondKey <= 0) RangedAtk(AtkType.two);
            }
            else if (pressed4)
            {
                if (pressed5) RangedAtk(AtkType.fourfive);
                else if (pressed6) RangedAtk(AtkType.foursix);
                else if (timeForSecondKey <= 0) RangedAtk(AtkType.four);
            }
            else if (pressed5)
            {
                if (pressed6) RangedAtk(AtkType.fivesix);
                else if (timeForSecondKey <= 0) RangedAtk(AtkType.five);
            }
            else if (pressed6)
            {
                if (timeForSecondKey <= 0) RangedAtk(AtkType.six);
            }
        }
    }

    private void RangedAtk(AtkType type) {
        float hpLoss = type switch
        {
            AtkType.one => hpLoss1,
            AtkType.two => hpLoss2,
            AtkType.four => hpLoss4,
            AtkType.five => hpLoss5,
            AtkType.six => hpLoss6,
            AtkType.onetwo => hpLoss7,
            AtkType.onethree => hpLoss8,
            AtkType.onefour => hpLoss9,
            AtkType.onefive => hpLoss10,
            AtkType.onesix => hpLoss11,
            AtkType.twothree => hpLoss12,
            AtkType.twofour => hpLoss13,
            AtkType.twofive => hpLoss14,
            AtkType.twosix => hpLoss15,
            AtkType.fourfive => hpLoss16,
            AtkType.foursix => hpLoss17,
            AtkType.fivesix => hpLoss18,
            _ => 0f
        };
        float cooldown = type switch
        {
            AtkType.one => cooldown1,
            AtkType.two => cooldown2,
            AtkType.four => cooldown4,
            AtkType.five => cooldown5,
            AtkType.six => cooldown6,
            AtkType.onetwo => cooldown7,
            AtkType.onethree => cooldown8,
            AtkType.onefour => cooldown9,
            AtkType.onefive => cooldown10,
            AtkType.onesix => cooldown11,
            AtkType.twothree => cooldown12,
            AtkType.twofour => cooldown13,
            AtkType.twofive => cooldown14,
            AtkType.twosix => cooldown15,
            AtkType.fourfive => cooldown16,
            AtkType.foursix => cooldown17,
            AtkType.fivesix => cooldown18,
            _ => 0f
        };
        GameObject projectile = type switch
        {
            AtkType.one => projectile1,
            AtkType.two => projectile2,
            AtkType.four => projectile4,
            AtkType.five => projectile5,
            AtkType.six => projectile6,
            AtkType.onetwo => projectile7,
            AtkType.onethree => projectile8,
            AtkType.onefour => projectile9,
            AtkType.onefive => projectile10,
            AtkType.onesix => projectile11,
            AtkType.twothree => projectile12,
            AtkType.twofour => projectile13,
            AtkType.twofive => projectile14,
            AtkType.twosix => projectile15,
            AtkType.fourfive => projectile16,
            AtkType.foursix => projectile17,
            AtkType.fivesix => projectile18,
            _ => null
        };
        bool rotateProj = type switch
        {
            AtkType.one => rotateProj1,
            AtkType.two => rotateProj2,
            AtkType.four => rotateProj4,
            AtkType.five => rotateProj5,
            AtkType.six => rotateProj6,
            AtkType.onetwo => rotateProj7,
            AtkType.onethree => rotateProj8,
            AtkType.onefour => rotateProj9,
            AtkType.onefive => rotateProj10,
            AtkType.onesix => rotateProj11,
            AtkType.twothree => rotateProj12,
            AtkType.twofour => rotateProj13,
            AtkType.twofive => rotateProj14,
            AtkType.twosix => rotateProj15,
            AtkType.fourfive => rotateProj16,
            AtkType.foursix => rotateProj17,
            AtkType.fivesix => rotateProj18,
        };
        bool selfCreate = type switch
        {
            AtkType.one => selfCreate1,
            AtkType.two => selfCreate2,
            AtkType.four => selfCreate4,
            AtkType.five => selfCreate5,
            AtkType.six => selfCreate6,
            AtkType.onetwo => selfCreate7,
            AtkType.onethree => selfCreate8,
            AtkType.onefour => selfCreate9,
            AtkType.onefive => selfCreate10,
            AtkType.onesix => selfCreate11,
            AtkType.twothree => selfCreate12,
            AtkType.twofour => selfCreate13,
            AtkType.twofive => selfCreate14,
            AtkType.twosix => selfCreate15,
            AtkType.fourfive => selfCreate16,
            AtkType.foursix => selfCreate17,
            AtkType.fivesix => selfCreate18,
        };

        if (healthh.health > 1) DamagePercentage(hpLoss);
        if (selfCreate) CreateProjectile(projectile, rotateProj, projCreationPoint);
        else CreateProjectile(projectile, rotateProj, otherPlayerTransform);
        currentCooldown = cooldown;
    }
    public void DamagePercentage(float damagePercentage) {
        damageToReceive = Mathf.Ceil(damagePercentage / 100 * healthh.health);
        damageReceived = (int)damageToReceive;
        if (damageReceived >= healthh.health) return;
        healthh.Dmg(damageReceived);
    }
    private void CreateProjectile(GameObject projectilee, bool rotateProj, Transform creationPoint)
    {
        if (rotateProj)
        {
            Quaternion projRotation = Quaternion.Euler(orientation.rotation.eulerAngles.x, orientation.rotation.eulerAngles.y, projectilee.transform.eulerAngles.z);
            Instantiate(projectilee, creationPoint.position, projRotation);
        }
        else
        {
            Quaternion projRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(projectilee, creationPoint.position, projRotation);
        }
    }
    private IEnumerator atkCoroutine()
    {
        yield return new WaitForSeconds(0.01f);
        pressed1 = false;
        pressed2 = false;
        pressed3 = false;
        pressed4 = false;
        pressed5 = false;
        pressed6 = false;
        hasPressed = false;
    }
}
