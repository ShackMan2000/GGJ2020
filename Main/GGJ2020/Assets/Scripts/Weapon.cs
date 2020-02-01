using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPF;


    [SerializeField]
    private Transform bulletSpawnPoint, playerTransform;

   

    private TileDestroyer destroyer;


    private void Awake()
    {
        destroyer = FindObjectOfType<TileDestroyer>();
    }




    public void Shoot(float direction)
    {               
        Bullet newBullet = Instantiate(bulletPF);
        newBullet.Activate(direction, bulletSpawnPoint.position, destroyer);
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
            Shoot(playerTransform.localScale.x);
    }






}
