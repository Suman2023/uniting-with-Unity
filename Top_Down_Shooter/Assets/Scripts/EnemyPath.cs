using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{   
    //config
    WaveConfig waveConfig; //connecting the WaveConfig script
    List<Transform> waypoints; // a list of path that enemy will follow
    
    int waypointsIndex = 0;



    //cache
    //state
    // Start is called before the first frame update
    void Start()
    {   
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PathToFollow();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }


    private void PathToFollow()
    {
        if(waypointsIndex < waypoints.Count)
            {
                var targetPos = waypoints[waypointsIndex].transform.position;
                var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
                transform.position = Vector2.MoveTowards(
                    transform.position,targetPos,movementThisFrame);

                if(transform.position == targetPos)
                    waypointsIndex++;
            }
        else 
        {
            Destroy(gameObject);
        }
    }
}
