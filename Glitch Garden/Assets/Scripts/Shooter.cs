using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject axePrefab, axePosObject;
    public void Fire()
    {
        Instantiate(axePrefab, axePosObject.transform.position, axePosObject.transform.rotation);
    }
}
