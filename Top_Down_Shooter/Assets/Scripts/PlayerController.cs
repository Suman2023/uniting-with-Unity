using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //config
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float padding = 0.5f;  // restricting the player from reaching the end of the boundary -> HTMLLLLLLLL
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float projectileSpeed = 10.0f;

    float xMin,xMax;
    float yMin, yMax;
    
    // Start is called before the first frame update
    void Start()
    {
        SetMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }


    private void Move()
    {   
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);


        transform.position = new Vector2(newXPos,newYPos);
        
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1")) //check input setting to see fire1 des
        {
            GameObject bullet = Instantiate(
                bulletPrefab,transform.position,
                Quaternion.identity) as GameObject; //Q.i -> no rotation

            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,projectileSpeed);

        }
    }

    private void SetMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;  //the boundaries of camera in unity is {(0,0) -> Botton-L,(1,0)-> Bottom-R,(0,1)-> Top-L,(1,1)-> Top-R}
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;


        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - padding;
    }
}
