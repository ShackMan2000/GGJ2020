using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatRef : ScriptableObject
{
   

    private int currentUnits;


    //use event OnValueChange

    public int CurrentUnits => currentUnits ;

 

    public void DeductMaterialForTile(int tilesToBuild)
    {

        currentUnits -= tilesToBuild;

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
