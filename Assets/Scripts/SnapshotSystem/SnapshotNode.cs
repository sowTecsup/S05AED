using UnityEngine;

public class SnapshotNode 
{
    public int Turn;

    public Vector3 playerPosition;
    public int str;
    public int dtx;
    public int spd;

    public SnapshotNode(Player player , int turn)
    {
        Turn = turn;

        playerPosition = player.transform.position;
        str = player.str;
        dtx = player.dtx;
        spd = player.spd;
    }

    
}
