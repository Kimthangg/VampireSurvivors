using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControler : MonoBehaviour
{
    public List<GameObject> terrainchunk;
    public float checkerRadius;
    public GameObject currentChunk;
    public LayerMask terrainMask;
    PlayerMovement player;
    Vector3 noTerrainPosition;

    [Header("Optimization")]
    public List<GameObject> spawnedChunk;
    GameObject latestChunk;
    public float maxOpDist;
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimazer();
    }

    void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }
        if (player.direction.x > 0 && player.direction.y == 0) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("right").position;
                SpawnChunk();
            }

        }
        else if (player.direction.x < 0 && player.direction.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("left").position;
                SpawnChunk();
            }
        }
        else if (player.direction.x == 0 && player.direction.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("up").position;
                SpawnChunk();
            }
        }
        else if (player.direction.x == 0 && player.direction.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("down").position;
                SpawnChunk();
            }
        }
        else if (player.direction.x > 0 && player.direction.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("right up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("right up").position;
                SpawnChunk();
            }
        }
        else if (player.direction.x < 0 && player.direction.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("left up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("left up").position;
                SpawnChunk();
            }
        }
        else if (player.direction.x > 0 && player.direction.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("right down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("right down").position;
                SpawnChunk();
            }
        }
        else if (player.direction.x < 0 && player.direction.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("left down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("left down").position;
                SpawnChunk();
            }
        }
    }
    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainchunk.Count);
        latestChunk = Instantiate(terrainchunk[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunk.Add(latestChunk);
        optimizerCooldown -= Time.deltaTime;

        if(optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }
    }
    
    void ChunkOptimazer()
    {
        foreach (GameObject chunk in spawnedChunk)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if(opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
