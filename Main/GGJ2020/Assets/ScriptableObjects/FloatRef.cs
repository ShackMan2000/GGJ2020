using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatRef : ScriptableObject
{
    [SerializeField]
    private int unitsPerTile;

    private int currentUnits;


    //use event OnValueChange

    public int AvailableUnites => Mathf.FloorToInt((float)currentUnits / (float)unitsPerTile);

 

    public void DeductMaterialForTile(int tilesToBuild)
    {

        currentUnits -= unitsPerTile * tilesToBuild;

    }


    public void SetUnitAmount(int newAmount)
    {
        currentUnits = newAmount;

    }

    public void AddUnitAmount(int addAmount)
    {
        currentUnits += addAmount;

    }


}
