using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook=nameof(OnChangeHealth))] public int currentHealth = maxHealth;
    public RectTransform healthbar;
    public bool destroyOnDeath;


    public void TakeDamage(int amount)
    {
        if (!GetComponent<NetworkIdentity>().hasAuthority) {
            Debug.Log("I am here. This is bad :(");
            return;
        }
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            if (destroyOnDeath) {
                Destroy(gameObject);
            }
            currentHealth = 0;
            Debug.Log("dead");
        }
        ChangeHealth();
        // healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
    }

    void OnChangeHealth(System.Int32 oldHealth, System.Int32 newHealth) {
        // Debug.Log("Hey");
        healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
        // currentHealth = newHealth;
    }

    void ChangeHealth() {
        // Debug.Log("Hey");
        healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
        // currentHealth = newHealth;
        CmdChangeHealth();
    }

    [Command]
    void CmdChangeHealth() {
        // Debug.Log("Hey");
        healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
        // currentHealth = newHealth;
        RpcChangeHealth() ;
    }

    [ClientRpc]
    void RpcChangeHealth() {
        // Debug.Log("Hey");
        healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
        // currentHealth = newHealth;
    }
}
