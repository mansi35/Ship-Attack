using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook=nameof(OnChangeHealth))] public int currentHealth = maxHealth;
    public RectTransform healthbar;


    public void TakeDamage(int amount)
    {
        if (!isServer) {
            return;
        }
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("dead");
        }

        // healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
    }

    void OnChangeHealth(System.Int32 oldHealth, System.Int32 newHealth) {
        // Debug.Log("Hey");
        healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
        // currentHealth = newHealth;
    }
}
