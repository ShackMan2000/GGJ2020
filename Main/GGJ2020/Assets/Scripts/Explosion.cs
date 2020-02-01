using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    


    private TileDestroyer destroyer;


    private void Awake()
    {
        destroyer = FindObjectOfType<TileDestroyer>();
    }



    public void Explode(Vector2 position, ExplosionDetails expDetails)
    {
        
        transform.position = position;

        StartCoroutine(ExplosionRoutine(expDetails));


    }





    private IEnumerator ExplosionRoutine(ExplosionDetails details)
    {
       // int listsToDestroy = details.;

        yield return null;

    }





}
