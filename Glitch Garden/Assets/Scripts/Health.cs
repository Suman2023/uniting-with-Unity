using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100.0f;
    [SerializeField] GameObject deathVFX;


    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {   
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX)
            return;
        GameObject deathVFXObj = Instantiate(deathVFX,transform.position, transform.rotation);
        Destroy(deathVFXObj,1f);
    }

    
}
