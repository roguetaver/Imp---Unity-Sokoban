using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverScript : MonoBehaviour
{
    public GameObject portaA;
    public GameObject portaB;
    public LayerMask acionantes;
    private Vector3 collisionUp;
    private Vector3 collisionDown;
    private Vector3 collisionLeft;
    private Vector3 collisionRight;
    public bool pisando;
    private Collider2D acionantesUp;
    private Collider2D acionantesDown;
    private Collider2D acionantesRight;
    private Collider2D acionantesLeft;
    private AudioSource audioS;

    void Start()
    {
        collisionUp = new Vector3 (this.transform.position.x, this.transform.position.y + 1, 0 );
        collisionDown = new Vector3 (this.transform.position.x, this.transform.position.y - 1, 0 );
        collisionRight = new Vector3 (this.transform.position.x + 1, this.transform.position.y, 0 );
        collisionLeft = new Vector3 (this.transform.position.x - 1 , this.transform.position.y, 0 );
        portaA.SetActive(true);
        portaB.SetActive(false);
        audioS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        acionantesUp= Physics2D.OverlapCircle(collisionUp, .2f , acionantes);
        acionantesDown= Physics2D.OverlapCircle(collisionDown, .2f , acionantes);
        acionantesRight= Physics2D.OverlapCircle(collisionRight, .2f , acionantes);
        acionantesLeft= Physics2D.OverlapCircle(collisionLeft, .2f , acionantes);

        if(acionantesUp){
            if(acionantesUp.transform.gameObject.tag == "Player"){
                if(acionantesUp.transform.gameObject.GetComponent<CharacterMovement>().CanPullLever){
                    pisando = true;
                }
            }
        }
        else if(acionantesDown){
            if(acionantesDown.transform.gameObject.tag == "Player"){
                if(acionantesDown.transform.gameObject.GetComponent<CharacterMovement>().CanPullLever){
                    pisando = true;
                }
            }
        }
        else if(acionantesRight){
            if(acionantesRight.transform.gameObject.tag == "Player"){
                if(acionantesRight.transform.gameObject.GetComponent<CharacterMovement>().CanPullLever){
                    pisando = true;
                }
            }
        }
        else if(acionantesLeft){
            if(acionantesLeft.transform.gameObject.tag == "Player"){
                if(acionantesLeft.transform.gameObject.GetComponent<CharacterMovement>().CanPullLever){
                    pisando = true;
                }
            }
        }
        else{
            pisando = false;
        }


        if(pisando){
            if (Input.GetKeyDown(KeyCode.E)){
                
                audioS.Play();
                if(portaA.activeSelf){
                    portaA.SetActive(false);
                }
                else{
                    portaA.SetActive(true);
                }
                
                if(portaB.activeSelf){
                    portaB.SetActive(false);
                }
                else{
                    portaB.SetActive(true);
                }
            } 
        }
    }
}
