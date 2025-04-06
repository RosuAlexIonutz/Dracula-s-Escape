using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttributesManager : MonoBehaviour
{
    public int health;
    public int attack;

    private bool hasChangedTo50Health = false;
    private bool hasChangedTo1Health = false;

    private Renderer npcRenderer;

    private void Start()
    {
        npcRenderer = GetComponent<Renderer>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }

        if (health == 1 && !hasChangedTo1Health)
        {
            hasChangedTo1Health = true;
        }

        if (health == 50 && !hasChangedTo50Health)
        {
            hasChangedTo50Health = true;
        }

        Debug.Log("Sanatatea NPC-ului: " + health);
    }

    private void Die()
    {
        Time.timeScale = 0f;

        // Face NPC-ul invizibil
        if (npcRenderer != null)
        {
            npcRenderer.enabled = false;
        }

        Debug.Log("NPC-ul a murit! Este acum invizibil.");

        SceneManager.LoadScene("Flappy Bat");
        Time.timeScale = 1;

    }


    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.TakeDamage(attack);
        }
    }
}
