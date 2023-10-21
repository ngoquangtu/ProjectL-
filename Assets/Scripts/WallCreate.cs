using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour
{
    public float gap = 0.25f;
    public int rows = 4;
    public int columns = 6;
    public GameObject Cube;
    private List<GameObject> boxes = new List<GameObject>();
    void Start()
    {


        for ( int j = 0; j < this.rows; j++) {
            for ( int i = 0; i < this.columns; i++ ) { // creates row
                float offset_x = this.columns / 2 - this.columns + i * (1.0f + this.gap);
                GameObject box = Instantiate(this.Cube, new Vector3(offset_x, j, 8), Quaternion.identity);
                box.SetActive(true);
                this.boxes.Add(box);
            }
        }


    }



}
