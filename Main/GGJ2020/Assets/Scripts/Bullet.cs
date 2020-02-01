using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    [SerializeField]
    private float speed;

    [SerializeField]
    private Explosion explosionPF;

    [SerializeField]
    private ExplosionDetails details;

    private float direction;

    private Rigidbody2D rigidBody;

    private TileDestroyer destroyer;





    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }



    public void Activate(float direction, Vector2 position, TileDestroyer tileDestroyer)
    {       
        transform.position = position;
        transform.localScale = new Vector2(transform.localScale.x * direction, transform.localScale.y);
        rigidBody.velocity = new Vector2(speed * direction, 0f);
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {        
      Explosion newExplosion = Instantiate(explosionPF);
        newExplosion.Explode(transform.position, details);
        Destroy(gameObject);
        
    }






}
