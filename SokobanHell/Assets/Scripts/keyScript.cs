using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    private Collider2D acionantes;
    public LayerMask acionantesLayer;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        acionantes = Physics2D.OverlapCircle(this.transform.position , .2f , acionantesLayer);

        if(acionantes){
            gameManager.GetComponent<LevelManager>().LoadNextLevel();
            this.transform.gameObject.SetActive(false); 
        }
    }
}
