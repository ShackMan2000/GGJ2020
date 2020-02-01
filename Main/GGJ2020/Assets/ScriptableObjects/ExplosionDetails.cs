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

        float r = width/2;

        float x_c = width /2;
        float y_c = height /2;


        string explosion_line_2d = "";
        for(int i = 0; i < width; i++){
            for(int j = 0; j < height; j++){

              float x_p = i;
              float y_p = j;
              
              float d = Mathf.Sqrt( 
                  (x_p - x_c)*(x_p - x_c) 
                + (y_p - y_c)*(y_p - y_c)
              );

              if(d < r){
                explosionList.Add( new Vector2(x_p, y_p));
                explosion_line_2d += "*";
              }
              else{
                explosion_line_2d += "_";
              }
            }
            explosion_line_2d+="\n";
        }
        Debug.Log(explosion_line_2d);

        // Debug.Log("Creating enemy number: " + i);
        // for(int i =0; i < explosionList.size(); i++){
        //   Debug.Log("whatever");
        // }
    }



}
