using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    //public Vector2 velocity;
    public Vector2 friction = new Vector2(.1f,0);
    public Animator ANIM_player;
    public float speed;
    public float speedRun; 
    public float forceJump = 2;
    private bool _isrunning = false;
    public PoolManager poolManager;
    //public GameObject projectile;
    public Transform positionToShoot;
    public Transform playerSideReference;

    // Update is called once per frame
    void Update()
    {
        HandleJump();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.S)){
            Shoot();
        }


    }

    private void HandleMovement(){

        _isrunning = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift));


        if (Input.GetKey(KeyCode.LeftArrow)){
            ANIM_player.SetBool("running",true); 
            
            if(_isrunning == false){
                player.velocity = new Vector2(-speed, player.velocity.y);
            }
            else {
                player.velocity = new Vector2(-speedRun, player.velocity.y);
            }
            player.velocity += friction;
            if (player.transform.localScale.x != -1){
                player.transform.DOScaleX(-1, .1f);
            } 
        }
        
        else if (Input.GetKey(KeyCode.RightArrow)){
            ANIM_player.SetBool("running",true);     

            if(_isrunning == false){
                player.velocity = new Vector2(speed, player.velocity.y);
            }
            else{
                player.velocity = new Vector2(speedRun, player.velocity.y);
            }
            player.velocity -= friction;
            if (player.transform.localScale.x != 1){
                player.transform.DOScaleX(1, .1f);
            }  
        }else{ANIM_player.SetBool("running",false);}
        

    }

    private void HandleJump(){

        if (Input.GetKeyDown(KeyCode.Space)){
            //ANIM_player.SetBool("isJumping",true);  
            player.velocity = Vector2.up * forceJump;
        }
        

    }


    private void Shoot(){
        var obj = poolManager.GetPooledObject();
        obj.SetActive(true);
        obj.GetComponent<Projectile>().StartProjectile();
        obj.transform.position = positionToShoot.transform.position;
        obj.GetComponent<Projectile>().side= playerSideReference.transform.localScale.x;
    }


}
