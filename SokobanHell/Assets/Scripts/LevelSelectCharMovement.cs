using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectCharMovement : MonoBehaviour
{
    public Vector3 pos;
    private float moveSpeed;
    public int currentLevel;
    public GameObject levelPointManager;
    public bool alreadyMoved;
    public FM fm;
    void Start()
    {
        fm = GameObject.Find("FM").GetComponent<FM>();
        moveSpeed = 6f;
        alreadyMoved = true;
        currentLevel = fm.level;
        pos = this.transform.position;
        levelPointManager = GameObject.Find("LevelSelectPoints");
    }

    void Update()
    { 

        pos = levelPointManager.GetComponent<LevelSelectManager>().pointsToMove[currentLevel - 1].position;
        transform.position = Vector3.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);  
        
        if(this.transform.position == pos){
            alreadyMoved = true;
        }
        else{
            alreadyMoved = false;
        }

        if(alreadyMoved){
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else{
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if(Input.GetAxisRaw("Horizontal") == 1 && alreadyMoved){
            if(currentLevel < levelPointManager.GetComponent<LevelSelectManager>().pointsToMove.Count){
                currentLevel += 1;
            }
            
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && alreadyMoved){
            if(currentLevel > 1){
                currentLevel -= 1;
            }
        }

        
    }
}
