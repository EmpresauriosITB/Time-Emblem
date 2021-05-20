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

    private float nextActionTime = 0.1f;
    public float period = 0.3f;

    private void Start()
    {
        
        gameObject.GetComponent<Unit>().tileX = (int)gameObject.transform.position.x;
        gameObject.GetComponent<Unit>().tileY = (int)gameObject.transform.position.y;

        moveSpeed = this.gameObject.GetComponent<CharacterController>().character.GetGridSpeed();
        locatePlayer();
        
    }

    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            int[] positionTarget = setTarget();

            Debug.Log("X & Y: x = " + positionTarget[0] + " y = " + positionTarget[1]);

            map.GeneratePathTo(positionTarget[0], positionTarget[1], gameObject);

            Debug.Log("EJECUTADO");
        }
       
       
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



}
