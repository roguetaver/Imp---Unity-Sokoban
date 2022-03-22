using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CharacterMovement : MonoBehaviour
{
    public Vector3 targetPos;
    private float moveSpeed;
    public LayerMask whatStopsMovement;
    public LayerMask killsPLayer;
    public LayerMask whatYouCanMove;
    public Collider2D boxCheckCollision;
    private GameObject box;
    public bool CanMoveBox;
    public bool CanPullLever;
    private Vector2 movement;
    private Animator animator;
    public bool IsPossessed;
    private bool done;
    private bool done1;


    void Start()
    {
        targetPos = this.transform.position;
        moveSpeed = 5f;
        animator = this.GetComponent<Animator>();
    }


    void Update()
    {
        if(!IsPossessed && !done){
            animator.SetBool("IsPossessed",false);
            done = true;
            done1 = false;
        }
        
        if(IsPossessed && !done1){
            done = false;
            done1 = true;
            animator.SetBool("IsPossessed",true);
        }

        if(!pauseMenu.gameIsPaused && IsPossessed){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal",movement.x);
            animator.SetFloat("Vertical",movement.y);
            animator.SetFloat("Speed",movement.sqrMagnitude);


            if (transform.position == targetPos){
                //===============================================================================================================
                //movimento horizontal
                //===============================================================================================================
                if (Math.Abs(Input.GetAxisRaw("Horizontal")) == 1f && (Math.Abs(Input.GetAxisRaw("Vertical")) == 0f)){

                    boxCheckCollision = Physics2D.OverlapCircle(targetPos + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatYouCanMove);
                    
                    //se houver uma caixa na direção em que o char pretende se mover
                    if (boxCheckCollision != null && CanMoveBox)
                    {
                        //se não houver parede na direção em que a caixa vai ser movida
                        //se não houver outra caixa na direção em que a caixa vai ser movida
                        if ((!Physics2D.OverlapCircle(targetPos + new Vector3(Input.GetAxisRaw("Horizontal") * 2, 0f, 0f), .2f, whatStopsMovement)) && (!Physics2D.OverlapCircle(targetPos + new Vector3(Input.GetAxisRaw("Horizontal") * 2, 0f, 0f), .2f, whatYouCanMove)))
                        {
                            //atualiza a posição da caixa e do char
                            box = boxCheckCollision.gameObject;
                            box.GetComponent<BoxMove>().MoveBox(targetPos + new Vector3(Input.GetAxisRaw("Horizontal") * 2, 0f, 0f));
                            targetPos += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }
                    }
                    else if (!Physics2D.OverlapCircle(targetPos + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement) && boxCheckCollision == null)
                    {
                        //move
                        targetPos += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }


                //===============================================================================================================
                //movimento vertical
                //===============================================================================================================
                else if (Math.Abs(Input.GetAxisRaw("Vertical")) == 1f && (Math.Abs(Input.GetAxisRaw("Horizontal")) == 0f))
                {

                    boxCheckCollision = Physics2D.OverlapCircle(targetPos + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatYouCanMove);
                    
                    //se houver uma caixa na direção em que o char pretende se mover
                    if (boxCheckCollision != null && CanMoveBox)
                    {
                        //se não houver parede na direção em que a caixa vai ser movida
                        //se não houver outra caixa na direção em que a caixa vai ser movida
                        if ((!Physics2D.OverlapCircle(targetPos + new Vector3(0f, Input.GetAxisRaw("Vertical") * 2, 0f), .2f, whatStopsMovement)) && (!Physics2D.OverlapCircle(targetPos + new Vector3(0f, Input.GetAxisRaw("Vertical") * 2, 0f), .2f, whatYouCanMove)))
                        {
                            //atualiza a posição da caixa e do char
                            box = boxCheckCollision.gameObject;
                            box.GetComponent<BoxMove>().MoveBox(targetPos + new Vector3(0f, Input.GetAxisRaw("Vertical") * 2, 0f));
                            targetPos += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }
                    }

                    else if (!Physics2D.OverlapCircle(targetPos + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement) && boxCheckCollision == null)
                    {   
                        //move
                        targetPos += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    }
                }
            }
        }  
    }
}
