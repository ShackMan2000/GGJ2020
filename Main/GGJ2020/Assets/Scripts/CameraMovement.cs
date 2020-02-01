using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float startSpeed, speedIncrease, speedIncreaseIntervall;

  


    private float speed,intervallCounter;

    public float maxX;



    private void Awake()
    {
        cam = GetComponent<Camera>();
        intervallCounter = speedIncreaseIntervall;
        speed = startSpeed;
    }






    private void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

     maxX = cam.ViewportToWorldPoint(new Vector2(1, 1)).x;


        CheckSpeedIncrease();

    }





    private void CheckSpeedIncrease()
    {
        intervallCounter -= Time.deltaTime;
        if (intervallCounter <= 0f)
        {
            intervallCounter = speedIncreaseIntervall;
            speed += speedIncrease;

        }
    }
}
