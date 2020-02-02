using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{


    [SerializeField]
    private ExplosionDetails details;

    
    [SerializeField]
    private Explosion explosionPF;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("bullet"))
        {
            Explosion newExplosion = Instantiate(explosionPF);
            newExplosion.Explode(transform.position, details);
            Destroy(gameObject);
        }
    }








}
