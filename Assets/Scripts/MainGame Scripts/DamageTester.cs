using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            playerAtm.DealDamage(enemyAtm.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.F12))
        {
            enemyAtm.DealDamage(playerAtm.gameObject);
        }
    }
}
