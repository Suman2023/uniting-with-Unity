using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletWaitTime = 0.0f;
    [SerializeField] float minWaitTime = 0.3f;
    [SerializeField] float maxWaitTime = 3.0f;

    
    [SerializeField] float health = 100;

    Coroutine firing;
    // Start is called before the first frame update
    void Start()
    {
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Fire()
    {   
        if(gameObject.name == "2 Bullet Enemy")
            StartCoroutine(fire2Bullets());
        else
            StartCoroutine(fire1Bullet());

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    { // To decrese health
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer)
            return;
        ProcessHit(damageDealer);
    }
    
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if(health <= 0)
        {   
            Instantiate(explosionPrefab,transform.position,Quaternion.identity);
            Destroy(parent);
        }
                
        
    }

    IEnumerator fire2Bullets()
    {
        while(true)
        {
        
        GameObject rightBullet = Instantiate(
            bulletPrefab, parent.transform.position + new Vector3(0.38f,0,0), Quaternion.identity
            ) as GameObject;

        rightBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-bulletSpeed);


        GameObject leftBullet = Instantiate(
            bulletPrefab, parent.transform.position - new Vector3(0.38f,0,0), Quaternion.identity
            ) as GameObject;

        leftBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-bulletSpeed);

        bulletWaitTime = Random.Range(minWaitTime,maxWaitTime);
        yield return new WaitForSeconds(bulletWaitTime);
        
        }
    }
    IEnumerator fire1Bullet()
    {
        while(true)
        {
        
        GameObject Bullet = Instantiate(
            bulletPrefab, parent.transform.position, Quaternion.identity
            ) as GameObject;

        Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-bulletSpeed);

        bulletWaitTime = Random.Range(minWaitTime,maxWaitTime);
        yield return new WaitForSeconds(bulletWaitTime);
        
        }
    }

    
}
