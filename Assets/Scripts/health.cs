using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class health : NetworkBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthbar;
    public bool destroyOnDeath;


    public void TakeDamage(int amount)
    {
        if (!isServer) {
            CmdChangeHealth(amount);
            Debug.Log("I am here. This is bad :(");
            return;
        }
        // currentHealth -= amount;
        // if(currentHealth <= 0)
        // {
        //     if (destroyOnDeath) {
        //         Destroy(gameObject);
        //     }
        //     currentHealth = 0;
        //     Debug.Log("dead");
        // }
        RpcChangeHealth(amount);
        // healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
    }

    // void ChangeHealth() {
    //     // Debug.Log("Hey");
    //     healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
    //     // currentHealth = newHealth;
    //     CmdChangeHealth();
    // }

    [Command]
    void CmdChangeHealth(int amount) {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            if (destroyOnDeath) {
                Destroy(gameObject);
            }
            currentHealth = 0;
            Debug.Log("dead");
        }
        // Debug.Log("Hey");
        healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
        // currentHealth = newHealth;
        RpcChangeHealth(amount) ;
    }

    [ClientRpc]
    void RpcChangeHealth(int amount) {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            if (destroyOnDeath) {
                Destroy(gameObject);
            }
            currentHealth = 0;
            Debug.Log("dead");
        }
        // Debug.Log("Hey");
        healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
        // currentHealth = newHealth;
    }
}
