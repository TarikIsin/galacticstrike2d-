using System.Collections;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float minX = -3.5f;
    [SerializeField] float maxX = 3.5f;
    [SerializeField] float Y = 12f;
    [SerializeField] float throwTime = 12f;


    [Header("Elements")]
    [SerializeField] GameObject[] planetPrefabs;

    private void Start()
    {
        StartCoroutine(PlanetThrow());
    }

    IEnumerator PlanetThrow()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, Y, 0f);
            int randomIndex = Random.Range(0, planetPrefabs.Length);
            GameObject planetPrefab = Instantiate(planetPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            
            Destroy(planetPrefab, 35);
            yield return new WaitForSeconds(throwTime);
        }
    }
}
