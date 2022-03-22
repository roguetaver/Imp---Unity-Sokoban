using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPoints : MonoBehaviour
{
    public bool unlocked;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!unlocked){
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);

        }
        else{
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
