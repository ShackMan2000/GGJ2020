using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ExplosionDetails : ScriptableObject
{
 
    [SerializeField]
    private List<List<Vector2>> explosionList = new List<List<Vector2>>();

    [SerializeField]
    private int width, height; //use odd numbers only

    [SerializeField]
    private float r_x, r_y; //use odd numbers only

    [SerializeField]
    private bool cross;

    [ContextMenu("FillList")]
    public void FillList()
    {

      explosionList.Clear();

        // float r_x = width /3.0f;
        // float r_y = height /2.0f;

        float x_c = width /2.0f - 0.5f;
        float y_c = height /2.0f - 0.5f;

        int max_expansion = r_x >= r_y ? (int)r_x : (int)r_y;


        //todo: co-routine c# 

        for(int k =1; k < max_expansion; k++){


          float r_x_applied = k<r_x ? k:r_x;
          float r_y_applied = k<r_y ? k:r_y;

          float r_x_crossed = r_y_applied;
          float r_y_crossed = r_x_applied;

          List<Vector2> explosionList_local = new List<Vector2>();


          string explosion_line_2d = "";
          explosion_line_2d+="explosion:\n";

          for(int i = 0; i < width; i++){

              explosion_line_2d += "explosion:";

              for(int j = 0; j < height; j++){

                int x_p = i;
                int y_p = j;

                float d_x = (x_p - x_c)*(x_p - x_c) / (r_x_applied * r_x_applied);
                float d_y = (y_p - y_c)*(y_p - y_c) / (r_y_applied * r_y_applied);


                bool was_set = false;
                float d_x_c = (x_p - x_c)*(x_p - x_c) / (r_x_crossed * r_x_crossed);
                float d_y_c = (y_p - y_c)*(y_p - y_c) / (r_y_crossed * r_y_crossed);

                if(
                  (d_x + d_y <= 1 || cross && (d_x_c + d_y_c <= 1))  
                ){

                  int final_x = (x_p - (int)((width/2) + 0.5f));
                  int final_y = (y_p - (int)((height/2)+ 0.5f));
                  explosionList_local.Add( new Vector2(final_x, final_y ));
                  string sign =" "; 
                  string val = ""+final_x;
                  if(final_x > 0){
                    sign =" ";
                  }
                  explosion_line_2d += sign+val;
                  was_set = true;
                }
                else{
                  explosion_line_2d += "__";
                }
              }
              explosion_line_2d+="\n";
          }
          explosion_line_2d+="explosion:\n";
          Debug.Log(explosion_line_2d);

          explosionList.Add(explosionList_local);
        }

        // Debug.Log("Creating enemy number: " + i);
        // for(int i =0; i < explosionList.size(); i++){
        //   Debug.Log("whatever");
        // }
    }



}
