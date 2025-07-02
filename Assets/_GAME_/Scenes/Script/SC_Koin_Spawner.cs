using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SC_Koin_Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int jumlahKoin = 5;
    public Tilemap tilemapGround;

    public Vector2 areaMin = new Vector2(-5, -5);
    public Vector2 areaMax = new Vector2(5, 5);

    void Start()
    {
        int attempts = 0;
        int maxAttempts = jumlahKoin * 10;
        int spawned = 0;

        while (spawned < jumlahKoin && attempts < maxAttempts)
        {
            attempts++;

            Vector3 spawnPos = new Vector3(
                Random.Range(areaMin.x, areaMax.x),
                Random.Range(areaMin.y, areaMax.y),
                0
            );

            Vector3Int tilePos = tilemapGround.WorldToCell(spawnPos);
            TileBase tile = tilemapGround.GetTile(tilePos);

            if (tile != null) // artinya tile ground ada
            {
                Vector3 center = tilemapGround.GetCellCenterWorld(tilePos);
                Instantiate(coinPrefab, center, Quaternion.identity);
                spawned++;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = (areaMin + areaMax) / 2f;
        Vector3 size = areaMax - areaMin;
        Gizmos.DrawWireCube(center, size);
    }

}

