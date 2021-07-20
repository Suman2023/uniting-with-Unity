using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{   
    Health health;

    [SerializeField] GameObject axePrefab, axePosObject;
    [SerializeField] float damage = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    public void Fire()  //called from attack animation
    {
        Instantiate(axePrefab, axePosObject.transform.position, axePosObject.transform.rotation);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Attacker")
        {
            health.DealDamage(damage);
        }
    }
}
