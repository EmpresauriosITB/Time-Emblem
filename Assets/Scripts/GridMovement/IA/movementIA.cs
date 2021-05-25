using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class movementIA : MonoBehaviour
{

    float moveSpeed;

    public TileMap map;
   
    GameObject player;

    private float nextActionTime ;
    private float period = 1f;

    private void Start()
    {
        
        gameObject.GetComponent<Unit>().tileX = (int)gameObject.transform.position.x;
        gameObject.GetComponent<Unit>().tileY = (int)gameObject.transform.position.y;

        moveSpeed = this.gameObject.GetComponent<CharacterController>().character.GetGridSpeed();
        locatePlayer();
        nextActionTime = Time.time + period;


    }

    private void Update()
    {
       
        moveIA();
    }

   

  
    void locatePlayer()
    {
        player = GameObject.Find("Unit");
    }

    int[] setTarget()
    {
        int targetx = gameObject.GetComponent<Unit>().tileX;
        int targety = gameObject.GetComponent<Unit>().tileY;


        float distancia = Vector3.Distance(player.transform.position, transform.position);
        if (distancia < moveSpeed)
        {
            targetx = player.GetComponent<Unit>().tileX;
            targety= player.GetComponent<Unit>().tileY;
        }
        
        int[] target = new int[] { targetx, targety };
        return target;
    }

    void moveIA()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            nextActionTime = Time.time + period;

            int[] positionTarget = setTarget();

            
            map.GeneratePathTo(positionTarget[0] +1, positionTarget[1] +1, gameObject);

            gameObject.GetComponent<Unit>().MoveNextTile();
            
        }
    }



}
