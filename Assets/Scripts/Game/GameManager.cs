using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> enemies;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<GameObject>(enemyObjects);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemies.Count > 0)
        {
            enemies.Remove(enemy);

            if(enemies.Count == 0) 
            {
                UIManager.Instance.OpenFinishPanel();
                Time.timeScale = 0f;
            }
        }

    }
}
