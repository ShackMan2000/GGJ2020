using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMover : MonoBehaviour
{



    [SerializeField]
    private CameraMovement cam;


    [SerializeField]
    private float speedAdjust;

    [SerializeField]
    private List<Transform> backGrounds;

    private float spriteWidth, spriteY;

    private Transform furthestRight;

    //  public float CamLeft { get => cam.transform.position.x - cam.orthographicSize;  }

    private void Awake()
    {
        spriteWidth = backGrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.extents.x * 2f * backGrounds[0].transform.localScale.x;

        spriteY = backGrounds[0].transform.position.y;


        for (int i = 0; i < backGrounds.Count; i++)
        {
            float newX =   spriteWidth * i; 
            backGrounds[i].transform.localPosition = new Vector2(newX, spriteY); 
        }

        furthestRight = backGrounds[backGrounds.Count - 1];

    }





    void Update()
    {

        foreach (var back in backGrounds)
        {
            if(back.position.x + spriteWidth < transform.position.x)
            {
               
             //   back.position = new Vector2(transform.position.x + spriteWidth * (float)(backGrounds.Count-1), spriteY);
                back.position = new Vector2(furthestRight.position.x + spriteWidth, spriteY);
                furthestRight = back;
            }

            back.position = new Vector2(back.position.x - cam.Speed * speedAdjust * Time.deltaTime, spriteY);
        }


        

    }
}
