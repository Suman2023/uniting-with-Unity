using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawnner : MonoBehaviour
{
    [SerializeField] bool spawn = true;

    [Header("Attacker")]
    [SerializeField] Attacker lizardPrefab;
    [SerializeField] Attacker foxPrefab;
    [SerializeField] List<GameObject> originPoints;

    float waitTimeBeforNextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnAttacker");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnAttacker()
    {
        while (spawn)
        {

            waitTimeBeforNextSpawn = Random.Range(1.0f, 1.2f);
            // //Think about this before watching the video
            // Debug.Log(originPoints[1].transform.position);
            yield return new WaitForSeconds(waitTimeBeforNextSpawn);
            Attackers();
        }

    }


    public void Attackers()
    {
        Instantiate(lizardPrefab, transform.position, Quaternion.identity);
        // Instantiate(foxPrefab, transform.position - new Vector3(0f, 3.0f, 0f), Quaternion.identity);
    }
}
