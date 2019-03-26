using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{

    public Text ScoreText;
    public int currentLevel;
    public float levelSizeY;
    private Vector2 nextLevelPos;
    public Text LevelText;

    public GameObject[] levelPrefabs;
    private GameObject newLevel;
    private GameObject curLevel;
    private GameObject oldLevel;
    public Canvas GameOver;

    //GameObject[] gmobj;
    //int gmobjlength;

    private void Start()
    {
        //ScoreText = GameManager.gm.GameplayUI.Find("ScorePlaceholder").Find("Score").GetComponent<Text>();
        //LevelText = GameManager.gm.GameplayUI.Find("LevelPlaceholder").Find("Level").GetComponent<Text>();
        //gmobj = GameObject.FindGameObjectsWithTag("Obstacle");
        //GameOver.enabled = false;
        nextLevelPos = new Vector2(nextLevelPos.x, nextLevelPos.y + levelSizeY);
        SpawnLevel();
    }

    private void Update()
    {
        ScoreText.text = Mathf.Max(0, Mathf.FloorToInt(transform.position.y)).ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("TRIGGER");

        if (other.tag == "Obstacle")
        {
            GameOver.enabled = true;
            Time.timeScale = 0f;

            /*print("DEAD");
            SceneManager.LoadScene("Gameplay");*/
            

        }
        else if (other.tag == "LevelEnd")
        {
            print("LevelEnd from balloon");
            other.tag = "Untagged"; //Can trigger only once (needs, bcz balloon has 2 colliders)
            SpawnLevel();
        }
    }


    public void SpawnLevel()
    {
        LevelText.text = currentLevel.ToString() + "/Many";
        currentLevel++;

        Destroy(oldLevel); //Removes old lvl
        if (currentLevel == 2) { oldLevel = GameObject.Find("Level_Start"); }
        else { oldLevel = curLevel; } //Moves cur lvl to old lvl
        SetOrderLayer(oldLevel, "OldLevel");

        curLevel = newLevel; //Moves new lvl to cur lvl
        SetOrderLayer(newLevel, "CurrentLevel");

        int randomLvl = Random.Range(0, levelPrefabs.Length);
        
        newLevel = Instantiate(levelPrefabs[randomLvl], nextLevelPos, Quaternion.identity); //Makes new lvl

        //gmobj = GameObject.FindGameObjectsWithTag("Obstacle");
        //float length = gmobj.Length;
        newLevel.transform.Find("LevelUI").Find("LevelNr").GetComponent<Text>().text = currentLevel.ToString();
        SetOrderLayer(newLevel, "NewLevel");

        nextLevelPos = new Vector2(nextLevelPos.x, nextLevelPos.y + levelSizeY);
    }

    private void SetOrderLayer(GameObject parentObject, string sortingLayerName)
    {
        if (parentObject)
        {
            for (int child = 0; child < parentObject.transform.childCount; child++)
            {
                if (parentObject.transform.GetChild(child).GetComponent<SpriteRenderer>())
                {
                    parentObject.transform.GetChild(child).GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
                }

                for (int subChild = 0; subChild < parentObject.transform.GetChild(child).childCount; subChild++)
                {
                    if (parentObject.transform.GetChild(child).GetChild(subChild).GetComponent<SpriteRenderer>())
                    {
                        parentObject.transform.GetChild(child).GetChild(subChild).GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
                    }

                    for (int subSubChild = 0; subSubChild < parentObject.transform.GetChild(child).GetChild(subChild).childCount; subSubChild++)
                    {
                        if (parentObject.transform.GetChild(child).GetChild(subChild).GetChild(subSubChild).GetComponent<SpriteRenderer>())
                        {
                            parentObject.transform.GetChild(child).GetChild(subChild).GetChild(subSubChild).GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
                        }
                    }
                }
            }
        } //Gonna break if nested more than 3 objects...
    }

}