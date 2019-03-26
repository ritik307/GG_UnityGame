using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{



    public GameObject Balloon;
    public GameObject Handle;
    public float x, y, z;
    private LineRenderer lineRenderer;
    


    void Start()
    {
       lineRenderer = GetComponent<LineRenderer>();

        
    }

    void Update()
    {
        lineRenderer.SetPosition(0, Balloon.transform.localPosition-new Vector3(-0.3f,2.5f,-10));
        lineRenderer.SetPosition(1, Handle.transform.localPosition);
    }

}
