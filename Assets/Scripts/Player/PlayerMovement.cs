using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    //public Vector2 velocity;
    public Vector2 friction = new Vector2(.1f,0);
    public float speed;
    public float speedRun; 
    public float forceJump = 2;
    private bool _isrunning = false;

    // Update is called once per frame
    void Update()
    {
        HandleJump();
        HandleMovement();

    }

    private void HandleMovement(){

        _isrunning = Input.GetKey(KeyCode.LeftControl);

        if (Input.GetKey(KeyCode.LeftArrow)){
            if(_isrunning == false){
                player.velocity = new Vector2(-speed, player.velocity.y);
            }
            else {
                player.velocity = new Vector2(-speedRun, player.velocity.y);
            }
            player.velocity += friction; 
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            if(_isrunning == false){
                player.velocity = new Vector2(speed, player.velocity.y);
            }
            else{
                player.velocity = new Vector2(speedRun, player.velocity.y);
            }
            player.velocity -= friction; 
        }

        

    }

    private void HandleJump(){

        if (Input.GetKeyDown(KeyCode.Space)){
            player.velocity = Vector2.up * forceJump;
        }
        

    }

}
