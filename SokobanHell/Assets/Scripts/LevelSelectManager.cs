using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public List<GameObject> levelPointsList;
    public List<Transform> pointsToMove;
    public GameObject charGameObject;
    public FM fm;

    void Start()
    {
        charGameObject = GameObject.Find("character");
        fm = GameObject.Find("FM").GetComponent<FM>();

        foreach (Transform child in this.transform)
        {
            levelPointsList.Add(child.gameObject);
        }

        for(int i = 0; i < fm.level; i++){
            levelPointsList[i].GetComponent<LevelSelectPoints>().unlocked = true;
            pointsToMove.Add(levelPointsList[i].transform);
        }

        charGameObject.transform.position = pointsToMove[charGameObject.GetComponent<LevelSelectCharMovement>().currentLevel - 1].position;
    }

    void Update()
    {
        if((Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space)) && charGameObject.GetComponent<LevelSelectCharMovement>().alreadyMoved){
            SceneManager.LoadScene(charGameObject.GetComponent<LevelSelectCharMovement>().currentLevel + 1);
        }
    }
}
