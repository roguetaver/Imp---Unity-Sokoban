using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FM : MonoBehaviour
{
    public int level = 1;
    
    private void Start() {
        int numFM = FindObjectsOfType<FM>().Length;
        if (numFM != 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        LoadData();
    }

    public void SaveData(){
        level = SceneManager.GetActiveScene().buildIndex ;
        SaveSystem.Save(this);
    }

    public void LoadData(){
        Data data = SaveSystem.Load();
        if (data == null){
            print("data null");
            level = 1;
        } else {
            level = data.level;
        }
    }

}
