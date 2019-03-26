using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int score;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(Input.touchCount>0)
		{
			Touch touch=Input.GetTouch(0);
			Vector3 touchPosition=Camera.main.ScreenToWorldPoint(touch.position);
			touchPosition.z=0f;
			transform.position=touchPosition;
		}

        score++;
        ScoreText.text = score.ToString();
    }
}
