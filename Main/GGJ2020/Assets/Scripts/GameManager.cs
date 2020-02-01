using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private FloatRef buildMaterial;

    [SerializeField]
    private ExplosionDetails[] explosions;


    [SerializeField]
    private int buildMaterialAtStartInUnits;




    private void Awake()
    {
        buildMaterial.SetUnitAmount(buildMaterialAtStartInUnits);

        InitialixeExplosionLists();

    }

    private void InitialixeExplosionLists()
    {
        foreach (var item in explosions)
        {
            item.FillList();
        }


    }
}
