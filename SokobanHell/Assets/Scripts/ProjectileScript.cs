using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public string direction;
    private Vector3 directionVector;
    private float speed;
    public LayerMask whatBreaksProjectile;
    public LayerMask playerLayer;
    private Collider2D wallCheckCollision;
    private Collider2D playerCheckCollision;
    public bool greenDemonHit;
    public bool purpleDemonHit;

    void Start()
    {
        speed = 9f;
    }

    // Update is called once per frame
    void Update()
    {
        wallCheckCollision = Physics2D.OverlapCircle(this.transform.position, .2f, whatBreaksProjectile);

        if(wallCheckCollision){
            if(wallCheckCollision.gameObject.tag == "Wall" || wallCheckCollision.gameObject.tag == "WhatCanBeMoved"){
                Destroy(this.gameObject);
            } 
        }

        playerCheckCollision = Physics2D.OverlapCircle(this.transform.position, .2f, playerLayer);

        if(playerCheckCollision){
            if(playerCheckCollision.gameObject.tag == "GreenDemon"){
                greenDemonHit = true;
            }
            else if (playerCheckCollision.gameObject.tag == "PurpleDemon"){
                purpleDemonHit = true;
            }
        }

        if(direction == "Up"){
            directionVector = new Vector3(0,1,0);
        }
        else if (direction == "Right"){
            directionVector = new Vector3(1,0,0);
        }
        else if (direction == "Left"){
            directionVector = new Vector3(-1,0,0);
        }
        else if (direction == "Down"){
            directionVector = new Vector3(0,-1,0);
        }
        else{
            directionVector = new Vector3(0,0,0);
        }

        transform.position += directionVector * Time.deltaTime * speed;
    }
}
