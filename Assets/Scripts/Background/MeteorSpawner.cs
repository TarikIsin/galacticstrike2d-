using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float minX = -3.5f;
    [SerializeField] float maxX = 3.5f;
    [SerializeField] float Y = 12f;
    [SerializeField] float throwTime = 5f;


    [Header("Elements")]
    [SerializeField] GameObject[] meteorPrefabs;

    private void Start()
    {
        StartCoroutine(MeteorThrow());
    }

    IEnumerator MeteorThrow()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, Y, 0f);
            int randomIndex = Random.Range(0, meteorPrefabs.Length);
            GameObject meteorPrefab = Instantiate(meteorPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            
            Destroy(meteorPrefab, 35);
            yield return new WaitForSeconds(throwTime);
        }
    }
}
