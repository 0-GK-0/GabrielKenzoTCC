using UnityEngine;

public enum AttackType { Light, Medium, Special }

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1.0f;
    public LayerMask enemyLayers;

    public float cooldown = 2f;
    private float _currentCooldown;

    void Update()
    {
        if (_currentCooldown > 0) _currentCooldown -= Time.deltaTime;
    }

    public void ExecuteAttack(AttackType type)
    {
        if (_currentCooldown == 0)
        {
            _currentCooldown = cooldown;
        }
        else return;
        
        float damagePercent = type switch
        {
            AttackType.Light => 0.10f,
            AttackType.Medium => 0.20f,
            AttackType.Special => 0.30f,
            _ => 0f
        };

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakePercentageDamage(damagePercent);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}