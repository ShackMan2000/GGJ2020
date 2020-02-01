using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ExplosionDetails : ScriptableObject
{
 
    [SerializeField]
    private List<Vector2> explosionList;


    [SerializeField]
    private float width, height;

    [SerializeField]
    private float r_x, r_y;

    // [SerializeField]
    // private bool cross;

    [ContextMenu("FillList")]
    public void FillList()
    {

        // float r_x = width /3.0f;
        // float r_y = height /2.0f;

        float x_c = width /2.0f - 0.5f;
        float y_c = height /2.0f - 0.5f;

        // float r_x_crossed = r_y;
        // float r_y_crossed = r_x;


        string explosion_line_2d = "";
        explosion_line_2d+="explosion:\n";

        for(int i = 0; i < width; i++){

            explosion_line_2d += "explosion:";

            for(int j = 0; j < height; j++){

              float x_p = (float)i;
              float y_p = (float)j;

              float d_x = (x_p - x_c)*(x_p - x_c) / (r_x * r_x);
              float d_y = (y_p - y_c)*(y_p - y_c) / (r_y * r_y);

              // if(cross){

              //   float d_x = (x_p - x_c)*(x_p - x_c) / (r_x_crossed * r_x_crossed);
              //   float d_y = (y_p - y_c)*(y_p - y_c) / (r_y_crossed * r_y_crossed);
                
              //   if(d_x + d_y <= 1){
              //     explosionList.Add( new Vector2(x_p, y_p));
              //     explosion_line_2d += "*";
              //   }
              // }


              if(d_x + d_y <= 1){
                explosionList.Add( new Vector2(x_p, y_p));
                explosion_line_2d += "*";
              }
              else{
                explosion_line_2d += "_";
              }

            }
            explosion_line_2d+="\n";
        }
        explosion_line_2d+="explosion:\n";
        Debug.Log(explosion_line_2d);

        // Debug.Log("Creating enemy number: " + i);
        // for(int i =0; i < explosionList.size(); i++){
        //   Debug.Log("whatever");
        // }
    }



}
