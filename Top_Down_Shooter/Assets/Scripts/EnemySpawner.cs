using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //config
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;
    int startingWave = 0;



    // Start is called before the first frame update
    IEnumerator Start()
    {   
        do
            yield return StartCoroutine(SpawnAllWaves());
        while(looping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; ++waveIndex)
        {   Debug.Log(waveIndex);
            var currWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currWave));
        }
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
