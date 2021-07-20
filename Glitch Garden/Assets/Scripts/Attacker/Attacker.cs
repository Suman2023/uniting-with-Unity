using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // config
    [SerializeField] float damage = 20.0f;
    
    
    float currentSpeed = 1.0f;
    Health health;

    private void Start() {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);

    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }



    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Weapon")
        {
            health.DealDamage(damage);
            Destroy(other.gameObject);
        }
    }


    
    
}
