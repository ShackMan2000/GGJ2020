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
    private Color availableColor, unavailableColor;

    [SerializeField]
    private Tile buildTilePF;

    private SpriteRenderer placeHolderSpriteRenderer;
    private float mapZ, widthOfTile;

    private Transform myTransform;





    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        mapZ = map.transform.position.z;
        placeHolderSpriteRenderer = placeHolderTransform.GetComponent<SpriteRenderer>();
        widthOfTile = placeHolderSpriteRenderer.sprite.bounds.size.x / 4f;
        availableColor = placeHolderSpriteRenderer.color;
    }



    private void Update()
    {
        Vector3Int positionInGrid = map.WorldToCell(myTransform.position);
        Vector2 positionUnadjusted = map.CellToWorld(positionInGrid);
        placeHolderTransform.position = positionUnadjusted + new Vector2(widthOfTile, widthOfTile);

       // placeHolderSpriteRenderer.color = buildMaterial.CurrentUnits >= 1 ? availableColor : unavailableColor;

        if (Input.GetKeyDown(KeyCode.B))
            BuildTile();
    }


    public void BuildTile()
    {

        Vector3Int positionInGrid = map.WorldToCell(placeHolderTransform.position);
        map.SetTile(positionInGrid, buildTilePF);

        buildMaterial.DeductMaterialForTile(1);

    }




}
