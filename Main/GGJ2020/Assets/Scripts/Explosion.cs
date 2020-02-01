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
        int listsToDestroy = details.explosionList.Count;
        print(listsToDestroy);
        float delay = details.delayBetweenRings;
        int count = 0;

        while(listsToDestroy > 0)
        {
            destroyer.DestroyTiles(transform.position, details.explosionList[count]);

            yield return new WaitForSeconds(delay);
            count ++;
            listsToDestroy --;
        }


        yield return null;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }



}
