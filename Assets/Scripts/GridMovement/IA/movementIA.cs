using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Linq;

public class movementIA : MonoBehaviour
{

    TileMap map;

    List<GameObject> enemies;
    GameObject closest;
    Vector3 position;
    

    private void Start()
    {
        map = this.gameObject.GetComponent<CharacterUnitController>().map;
    }

    
    public GameObject locateTarget(bool targetIsPlayer)
    {
        if (targetIsPlayer)
        {
            enemies = BattleData.playerTeam;
        }
        else{
            enemies = BattleData.enemyTeam;
        }

        
        position = transform.position;

        if (enemies.Count == 0)
        {
            Debug.LogWarning("No enemies found!", this);
            return null;
        }

        
        if (enemies.Count == 1)
        {
            closest = enemies[0];
            
            return closest;
        }

        // Otherwise: Take the enemies
        enemies = enemies.OrderBy(go => (position - go.transform.position).sqrMagnitude).ToList();

        for (int i = 0; i < enemies.Count; i++) {
            if (!enemies[i].GetComponent<CharacterUnitController>().isDead) {
                closest = enemies[i];
            }
        }
           
        return closest;
    }

    public int[] setTarget()
    {
        
        int targetx = locateTarget(true).GetComponent<Unit>().tileX;
        int targety = locateTarget(true).GetComponent<Unit>().tileY;
        
        int[] target = new int[] { targetx, targety };
        return target;
    }

    public void moveIA(int[] target)
    {
       
        int[] positionTarget = target;
        Unit u = gameObject.GetComponent<Unit>();

        // X enemy < X ia && Y enemy < Y ia
        if (u.tileX > positionTarget[0] && u.tileY > positionTarget[1])
        {
            map.GeneratePathTo(positionTarget[0] +1, positionTarget[1] +1, gameObject);
        }
        // X enemy < X ia && Y enemy > Y ia
        else if (u.tileX > positionTarget[0] && u.tileY < positionTarget[1])
        {
            map.GeneratePathTo(positionTarget[0] + 1, positionTarget[1] - 1, gameObject);
        }
        // X enemy > X ia && Y enemy > Y ia
        else if (u.tileX < positionTarget[0] && u.tileY < positionTarget[1])
        {
            map.GeneratePathTo(positionTarget[0] - 1, positionTarget[1] - 1, gameObject);
        }
        // X enemy > X ia && Y enemy < Y ia
        else if (u.tileX < positionTarget[0] && u.tileY > positionTarget[1])
        {
            map.GeneratePathTo(positionTarget[0] - 1, positionTarget[1] + 1, gameObject);
        }
        // X enemy = X ia && Y enemy > Y ia
        else if (u.tileX == positionTarget[0] && u.tileY < positionTarget[1])
        {
            map.GeneratePathTo(positionTarget[0], positionTarget[1] - 1, gameObject);
        }
        // X enemy = X ia && Y enemy < Y ia
        else if (u.tileX == positionTarget[0] && u.tileY < positionTarget[1])
        {
            map.GeneratePathTo(positionTarget[0], positionTarget[1] + 1, gameObject);
        }
        // X enemy < X ia && Y enemy = Y ia
        else if (u.tileX > positionTarget[0] && u.tileY == positionTarget[1])
        {

            map.GeneratePathTo(positionTarget[0] +1, positionTarget[1], gameObject);
        }
        // X enemy > X ia && Y enemy = Y ia
        else if (u.tileX > positionTarget[0] && u.tileY == positionTarget[1])
        {
            map.GeneratePathTo(positionTarget[0] - 1, positionTarget[1], gameObject);
        }
        u.MoveNextTile();

        
            
    }




    
}
