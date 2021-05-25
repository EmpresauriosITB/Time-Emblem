using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Linq;

public class movementIA : MonoBehaviour
{

    float moveSpeed;

    public TileMap map;
   
    

    GameObject[] enemies;
    GameObject closest;
    Vector3 position;
    private float nextActionTime ;
    private float period = 1f;

    private void Start()
    {
        
        gameObject.GetComponent<Unit>().tileX = (int)gameObject.transform.position.x;
        gameObject.GetComponent<Unit>().tileY = (int)gameObject.transform.position.y;

        moveSpeed = this.gameObject.GetComponent<CharacterController>().character.GetGridSpeed();
        enemies = GameObject.FindGameObjectsWithTag("Allied");
        
        nextActionTime = Time.time + period;
       

    }

    private void Update()
    {
        moveIA();
    }

   

  
    GameObject locatePlayer()
    {
                
        position = transform.position;

        if (enemies.Length == 0)
        {
            Debug.LogWarning("No enemies found!", this);
            return null;
        }

        // If there is only exactly one anyway skip the rest and return it directly
        if (enemies.Length == 1)
        {
            closest = enemies[0];
            return closest;
        }


        // Otherwise: Take the enemies
        closest = enemies.OrderBy(go => (position - go.transform.position).sqrMagnitude).First();
        // Order them by distance (ascending) => smallest distance is first element

        // Get the first element


        // target.transform.position = closest.transform.position;
        Debug.Log(closest.name);
        return closest;
    }

    int[] setTarget()
    {
        int targetx = gameObject.GetComponent<Unit>().tileX;
        int targety = gameObject.GetComponent<Unit>().tileY;


        float distancia = Vector3.Distance(locatePlayer().transform.position, transform.position);
        
        
        if (distancia < moveSpeed)
        {
            targetx = locatePlayer().GetComponent<Unit>().tileX;
            targety= locatePlayer().GetComponent<Unit>().tileY;
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
