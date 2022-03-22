using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject projectile;
    private GameObject currentProjectile;
    private GameObject RedDemonGameObject;
    private GameObject PurpleDemonGameObject;
    private GameObject GreenDemonGameObject;


    void Start()
    {
        RedDemonGameObject = GameObject.Find("RedDemon");
        GreenDemonGameObject = GameObject.Find("GreenDemon");
        PurpleDemonGameObject = GameObject.Find("PurpleDemon");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentProjectile == null && RedDemonGameObject.GetComponent<CharacterMovement>().IsPossessed){

            if(Input.GetKeyUp(KeyCode.UpArrow)){
            currentProjectile = Instantiate(projectile,RedDemonGameObject.transform.position,Quaternion.identity);
            currentProjectile.gameObject.GetComponent<ProjectileScript>().direction = "Up";
            }
            else if(Input.GetKeyUp(KeyCode.RightArrow)){
                currentProjectile = Instantiate(projectile,RedDemonGameObject.transform.position,Quaternion.identity);
                currentProjectile.gameObject.GetComponent<ProjectileScript>().direction = "Right";
            }
            else if(Input.GetKeyUp(KeyCode.LeftArrow)){
                currentProjectile = Instantiate(projectile,RedDemonGameObject.transform.position,Quaternion.identity);
                currentProjectile.gameObject.GetComponent<ProjectileScript>().direction = "Left";
            }
            else if(Input.GetKeyUp(KeyCode.DownArrow)){
                currentProjectile = Instantiate(projectile,RedDemonGameObject.transform.position,Quaternion.identity);
                currentProjectile.gameObject.GetComponent<ProjectileScript>().direction = "Down";
            }
        }
        else if (currentProjectile != null) {
            if(currentProjectile.GetComponent<ProjectileScript>().greenDemonHit){
                GreenDemonGameObject.GetComponent<CharacterMovement>().AddSoul();
                RedDemonGameObject.GetComponent<CharacterMovement>().RemoveSoul();
                Destroy(currentProjectile);
            }
            else if (currentProjectile.GetComponent<ProjectileScript>().purpleDemonHit){
                PurpleDemonGameObject.GetComponent<CharacterMovement>().AddSoul();
                RedDemonGameObject.GetComponent<CharacterMovement>().RemoveSoul();
                Destroy(currentProjectile);
            }
        }

        if (PurpleDemonGameObject.GetComponent<CharacterMovement>().IsPossessed){
            if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ){
                PurpleDemonGameObject.GetComponent<CharacterMovement>().RemoveSoul();
                RedDemonGameObject.GetComponent<CharacterMovement>().AddSoul();
            }
        }

        else if (GreenDemonGameObject.GetComponent<CharacterMovement>().IsPossessed){
            if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ){
                GreenDemonGameObject.GetComponent<CharacterMovement>().RemoveSoul();
                RedDemonGameObject.GetComponent<CharacterMovement>().AddSoul();
            }
        }
        

    }
}
