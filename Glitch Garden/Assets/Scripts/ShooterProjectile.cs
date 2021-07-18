using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterProjectile : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] float projectileSpeed = 1.0f;
    [SerializeField] float rotationDegree = -180.0f;
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
        // transform.eulerAngles = Vector3.forward * rotationDegree;
    }
}
