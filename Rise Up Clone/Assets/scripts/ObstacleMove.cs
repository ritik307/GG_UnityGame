using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            col.gameObject.tag = "ObstacleTouch";
            col.gameObject.AddComponent<ObstacleMove>();
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }*/
}
