using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public FM fm;
    private AudioSource audioS; 
    public AudioClip[] audioClipList;
    private bool done;

    void Start()
    {
        fm = GameObject.Find("FM").GetComponent<FM>();
        audioS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        audioS.clip = audioClipList[1];
       
        if(!done){
            audioS.Play();
            done = true;
        }
        StartCoroutine(ResetLevelAfterSec(0.5f));
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex  > fm.level){
            fm.SaveData();
        }
        audioS.clip = audioClipList[0];
        audioS.Play();
        
        StartCoroutine(NextLevelAfterSec(1f));
    }

    public IEnumerator NextLevelAfterSec(float sec)
    {  
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator ResetLevelAfterSec(float sec)
    {  
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
