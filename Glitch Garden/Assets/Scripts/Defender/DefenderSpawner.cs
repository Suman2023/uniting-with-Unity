using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{   
    [SerializeField] GameObject defenderPrefab;
    private void OnMouseUp()
    {   
        Vector2 spawnPos = GetSqaureClicked();
        SpawnDefender(spawnPos);
    }

    private Vector2 GetSqaureClicked()
    {
        Vector2 clickedPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2  worldPos = Camera.main.ScreenToWorldPoint(clickedPos);

        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        Vector2 gridPos = new Vector2(newX,newY);
        return gridPos;

    }
    private void SpawnDefender(Vector2 spawnPos)
    {   
        GameObject newDefender = Instantiate(defenderPrefab, new Vector2(spawnPos.x,spawnPos.y), Quaternion.identity) as GameObject;
        // Destroy(newDefender, 20.0f);
    }
}
