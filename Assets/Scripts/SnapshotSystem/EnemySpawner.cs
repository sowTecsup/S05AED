using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Enemy EnemyPrefab;
    public int range;
    public List<Enemy> enemies =new();
    private void OnEnable()
    {

       
    }

  

    void Start()
    {
        GameManager.instance.OnPassTurn += MoveEnemies;
        GameManager.instance.OnPassTurn += CreateEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void MoveEnemies()
    {
        GameManager.instance.EnablePlayerTurn = false;  
        foreach (var enemy in enemies)
        {
            enemy.MoveToTarget();
        }

        Invoke(nameof(EnableTurn) , 1);
    }
    private void CreateEnemy()
    {
        Vector3Int randomPos = new Vector3Int(UnityEngine.Random.Range(-range, range), 1, UnityEngine.Random.Range(-range, range));
        Enemy enemy = Instantiate(EnemyPrefab);
        enemy.Set(GameManager.instance.player.transform, randomPos);
        enemies.Add(enemy); 


    }
    public void ClearEnemies()
    {
        foreach (var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        enemies.Clear();

    }
    public void LoadEnemies(List<Vector3> EnemiesPos)
    {
        foreach(var pos in EnemiesPos)
        {
            Enemy enemy = Instantiate(EnemyPrefab);
            enemy.Set(GameManager.instance.player.transform, pos);
            enemies.Add(enemy);
        }
    }

    void EnableTurn()
    {
        GameManager.instance.EnablePlayerTurn = true;
    }
}
