using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletWaitTime = 0.5f;
    [SerializeField] GameObject parent;

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


    IEnumerator fire2Bullets()
    {
        while(true)
        {
        yield return new WaitForSeconds(bulletWaitTime);
        GameObject rightBullet = Instantiate(
            bulletPrefab, parent.transform.position + new Vector3(0.38f,0,0), Quaternion.identity
            ) as GameObject;

        rightBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-bulletSpeed);


        GameObject leftBullet = Instantiate(
            bulletPrefab, parent.transform.position - new Vector3(0.38f,0,0), Quaternion.identity
            ) as GameObject;

        leftBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-bulletSpeed);

        
        }
    }
    IEnumerator fire1Bullet()
    {
        while(true)
        {
        yield return new WaitForSeconds(bulletWaitTime);
        GameObject Bullet = Instantiate(
            bulletPrefab, parent.transform.position, Quaternion.identity
            ) as GameObject;

        Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-bulletSpeed);

        
        }
    }

    private void Fire()
    {   
        if(gameObject.name == "2 Bullet Enemy")
            StartCoroutine(fire2Bullets());
        else
            StartCoroutine(fire1Bullet());

    }
}
