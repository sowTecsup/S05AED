using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;

    public float smoothing = 5.0f;


    void Start()
    {
       // GameManager.instance.OnPassTurn += MoveToTarget;
    }

    


    void Update()
    {
        
    }
    public void Set(Transform target , Vector3 position)
    {
        this.target = target;   
        transform.position = position;
    }
    public void MoveToTarget()
    {
        Vector3 targetPos = GetClosetStep();

        transform.position =  targetPos;
       // transform.Translate()
    }
    public Vector3 GetClosetStep()
    {
        Vector3 currentPosition = transform.position;
        Vector3 pos1 = transform.position + new Vector3(GameManager.TileValue, 0, 0);
        Vector3 pos2 = transform.position + new Vector3(0, 0, GameManager.TileValue);
        float distance1 = Vector3.Distance(pos1, target.position);
        float distance2 = Vector3.Distance(pos2, target.position);

        return distance1 < distance2 ? pos1 : pos2 ;
    }
  
}
