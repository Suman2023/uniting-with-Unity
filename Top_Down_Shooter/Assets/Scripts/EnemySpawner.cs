using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //config
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;



    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {   
        for(int i = 0; i < waveConfig.GetNumberOfEnemies(); ++i)
        {
            var newEnemy = Instantiate(
                            waveConfig.GetEnemyPrefab(),
                            waveConfig.GetWayPoints()[0].transform.position,
                            Quaternion.identity
                        );
            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(
                waveConfig.GetTimeBetweenSpawns());
        }
    }
}
