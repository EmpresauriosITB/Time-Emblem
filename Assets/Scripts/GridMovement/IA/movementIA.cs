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
    

    private void Start()
    {
        
        gameObject.GetComponent<Unit>().tileX = (int)gameObject.transform.position.x;
        gameObject.GetComponent<Unit>().tileY = (int)gameObject.transform.position.y;

        moveSpeed = this.gameObject.GetComponent<CharacterUnitController>().character.currentGridSpeed;
        
        
       

    }

    private void Update()
    {
       
    }

   

  
    public GameObject locatePlayer()
    {
        enemies = GameObject.FindGameObjectsWithTag("Allied");
        position = transform.position;

        if (enemies.Length == 0)
        {
            Debug.LogWarning("No enemies found!", this);
            return null;
        }

        
        if (enemies.Length == 1)
        {
            closest = enemies[0];
            return closest;
        }


        // Otherwise: Take the enemies
        closest = enemies.OrderBy(go => (position - go.transform.position).sqrMagnitude).First();
                
        return closest;
    }

    public int[] setTarget()
    {
        
        int targetx = locatePlayer().GetComponent<Unit>().tileX;
        int targety = locatePlayer().GetComponent<Unit>().tileY;
        
        int[] target = new int[] { targetx, targety };
        return target;
    }

    public void moveIA(int[] target)
    {
       
        int[] positionTarget = target;
                   
        map.GeneratePathTo(positionTarget[0] +1, positionTarget[1] +1, gameObject);

        gameObject.GetComponent<Unit>().MoveNextTile();

        gameObject.GetComponent<StatesMachine>().state = StatesMachine.State.NotActive;
    }




    
}
