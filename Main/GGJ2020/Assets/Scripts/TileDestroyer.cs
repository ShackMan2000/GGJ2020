using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    [SerializeField]
    private Tilemap mapToDestroy;

    private int mapZ;



    private void Awake()
    {
        mapZ = mapToDestroy.WorldToCell(mapToDestroy.transform.position).z;
    }





    public void DestroyTiles(Vector2 startpositionWorld, List<Vector2Int> destroyList)
    {
      
        Vector3Int startPos = mapToDestroy.WorldToCell(startpositionWorld);
       

        foreach (var pos in destroyList)
        {      
            mapToDestroy.SetTile(new Vector3Int(pos.x + startPos.x, pos.y + startPos.y, mapZ), null);
           
        }




    }




}
