using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceHolderTile : MonoBehaviour
{
  
    [SerializeField]
    private FloatRef buildMaterial;
    
    [SerializeField]
    private Transform placeHolderTransform;


    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private Tile buildTilePF;

    private float mapZ;

    private Transform myTransform;



    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        mapZ = map.transform.position.z;
    }



    private void Update()
    {
        Vector3Int positionInGrid = map.WorldToCell(myTransform.position);
        placeHolderTransform.position = map.CellToWorld(positionInGrid);      


        if(Input.GetKeyDown(KeyCode.B))
            BuildTile();
    }


    public void BuildTile()
    {

        Vector3Int positionInGrid = map.WorldToCell(placeHolderTransform.position);
        map.SetTile(positionInGrid, buildTilePF);

    }




}
