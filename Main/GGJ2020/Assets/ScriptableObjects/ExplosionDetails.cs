using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ExplosionDetails : ScriptableObject
{
 
    [SerializeField]
    private List<Vector2> explosionList;


    [SerializeField]
    private int width, height;



    [ContextMenu("FillList")]
    public void FillList()
    {
        Debug.Log("whatever");

    }



}
