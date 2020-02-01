using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatRef : ScriptableObject
{
    [SerializeField]
    private float unitsPerTile;

    private float currentUnits;


    //use event OnValueChange

    public int AvailableUnites => Mathf.FloorToInt(currentUnits / unitsPerTile);

 

    public void DeductMaterialForTile(int tilesToBuild)
    {

        currentUnits -= unitsPerTile * (float) tilesToBuild;

    }

}
