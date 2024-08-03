using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public SOPlayerController playerElement;
    public Rigidbody2D player;
    public Animator ANIM_player;
    

    public PoolManager poolManager;
    public Transform positionToShoot;
    public Transform playerSideReference;

    [Header("Jump Collision Settings")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .1f;

    
    public ParticleSystem ParticleRun;
    public ParticleSystem ParticleJump;

private  void Awake(){

    if (collider2D != null){
        distToGround = collider2D.bounds.extents.y;
    }

}

private bool isGrounded(){
    //Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
    return Physics2D.Raycast(transform.position, -Vector2.up,distToGround + spaceToGround);
}



    void Update()
    {
           
        HandleJump();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.S)){
            Shoot();
        }


    }

    private void HandleMovement(){

        playerElement._isrunning = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift));



        if (Input.GetKey(KeyCode.LeftArrow)){
            ANIM_player.SetBool("running",true); 
            
            ActiveParticlesRun();


            if(playerElement._isrunning == false){
                player.velocity = new Vector2(-playerElement.speed, player.velocity.y);
            }
            else {
                player.velocity = new Vector2(-playerElement.speedRun, player.velocity.y);
            }
            player.velocity += playerElement.friction;
            if (player.transform.localScale.x != -1){
                player.transform.DOScaleX(-1, .1f);
            } 
        }
        
        else if (Input.GetKey(KeyCode.RightArrow)){
            ANIM_player.SetBool("running",true);     
            ActiveParticlesRun();
            if(playerElement._isrunning == false){
                player.velocity = new Vector2(playerElement.speed, player.velocity.y);
            }
            else{
                player.velocity = new Vector2(playerElement.speedRun, player.velocity.y);
            }
            player.velocity -= playerElement.friction;
            if (player.transform.localScale.x != 1){
                player.transform.DOScaleX(1, .1f);
            }  
        }else{ANIM_player.SetBool("running",false);}
        

    }

    private void HandleJump(){

        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded()){
            //ANIM_player.SetBool("isJumping",true);  
            player.velocity = Vector2.up * playerElement.forceJump;
        
            if(ParticleJump != null){
                ParticleJump.Play();
            }
        }
        

    }


    private void Shoot(){
        var obj = poolManager.GetPooledObject();
        obj.SetActive(true);
        obj.GetComponent<Projectile>().StartProjectile();
        obj.transform.position = positionToShoot.transform.position;
        obj.GetComponent<Projectile>().side= playerSideReference.transform.localScale.x;
    }


    private void ActiveParticlesRun(){
                
               /* if (ParticleRun != null){

                    if (isGrounded()) {
                        if (!ParticleRun.isPlaying) {
                            ParticleRun.Play();
                        }
                    } 
                    else {
                        if (ParticleRun.isPlaying) {
                            ParticleRun.Stop();
                        }
                    }
                }
               
            */
    }

}
