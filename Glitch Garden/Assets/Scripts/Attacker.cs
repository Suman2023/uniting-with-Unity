using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // config

    float currentSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);

    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
