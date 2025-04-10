using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public string playerName;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakePercentageDamage(float percent)
    {
        float damage = currentHealth * percent;
        currentHealth -= damage;
        Debug.Log(playerName + " tomou " + damage + " de dano!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(playerName + " morreu!");
        gameObject.SetActive(false);
        GameManager.Instance.PlayerDied(playerName);
    }
}