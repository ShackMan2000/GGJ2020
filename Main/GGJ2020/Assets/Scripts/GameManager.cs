using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private FloatRef buildMaterial;


    [SerializeField]
    private int buildMaterialAtStartInUnits;




    private void Awake()
    {
        buildMaterial.SetUnitAmount(buildMaterialAtStartInUnits);


    }



}
