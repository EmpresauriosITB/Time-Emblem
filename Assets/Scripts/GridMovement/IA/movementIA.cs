using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movementIA : MonoBehaviour
{

    float radiusVision = 30f;
    float speed = 8f;

    public TileMap map;

    private Vector3 startingPosition;
   
    GameObject player;
    
    private void Start()
    {
        startingPosition = transform.position;     
        gameObject.GetComponent<Unit>().tileX = (int)gameObject.transform.position.x;
        gameObject.GetComponent<Unit>().tileY = (int)gameObject.transform.position.y;
        
    }

    private void Update()
    {
        locatePlayer();
        setTarget();
        Debug.Log(setTarget().x + " - " + setTarget().y);
        
        map.GeneratePathTo((int)setTarget().x, (int)setTarget().y, gameObject);
    }

    void locatePlayer()
    {
        player = GameObject.Find("Unit");
    }

    Vector3 setTarget()
    {
        Vector3 target = startingPosition;
        float distancia = Vector3.Distance(player.transform.position, transform.position);
        if (distancia < radiusVision) target = player.transform.position;
        return target;
    }



}
