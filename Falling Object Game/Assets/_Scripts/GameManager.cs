using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sphere[] prefab;
    [SerializeField] private PlayerMovement playerMovement;
    private Coroutine spawnCorutine;
    private List<Sphere> spawnedSpheres = new List<Sphere>();

    public void StartGame()
    {
        CleanupScene();
        playerMovement.RestartGame();
        if (spawnCorutine == null)
        {
            spawnCorutine = StartCoroutine(SpawnRoutine());
        }
    }

    public void CleanupScene()
    {
        foreach (var sphere in spawnedSpheres)
        {
            if (sphere != null)
                Destroy(sphere.gameObject);
        }
        spawnedSpheres.Clear();
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            RandomSpawnPoint();
        }
    }

    private float RandomDistanceX()
    {
        return Random.Range(-5, 5);
    }

    private void RandomSpawnPoint()
    {
        var sphere = Instantiate(prefab[RandomIndex()], new Vector3(RandomDistanceX(), 8, -12), Quaternion.identity);
        spawnedSpheres.Add(sphere);
    }

    private int RandomIndex()
    {
        return Random.Range(0, prefab.Length);
    }
}
