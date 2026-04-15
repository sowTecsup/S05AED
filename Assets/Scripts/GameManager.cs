using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CustomDoubleLinkedList snapshotSystem = new();

    public EnemySpawner spawner;
    public Player player;
    public static int TileValue = 2;

    public bool EnablePlayerTurn = true;
    public Action OnPassTurn;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
       OnPassTurn += SaveTurn;
    }

    void Start()
    {

    }
    void Update()
    {

     /*   */
    }

    public void SaveTurn()
    {
        snapshotSystem.SaveTurn();
        Debug.Log("Saving turn: " + snapshotSystem.Count);
    }
    //[Button]
    public void LoadTurn()
    {
        snapshotSystem.LoadTurn(player,spawner);
    }
    [Button]
    public void NextTurn()
    {
        snapshotSystem.MoveForward();
        LoadTurn();
    }
    [Button]
    public void PrevTurn()
    {
        snapshotSystem.MoveBackwards();
        LoadTurn();
    }

    
  

}