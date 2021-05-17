using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movementIA : MonoBehaviour
{

    float radiusVision = 20f;
    float speed = 8f;


    private Vector3 startingPosition;

    GameObject player;
    

    private void Start()
    {
        startingPosition = transform.position;
        player = GameObject.Find("Unit");
    }

    private void Update()
    {
        Vector3 target = startingPosition;

        float distancia = Vector3.Distance(player.transform.position, transform.position);
        if (distancia < radiusVision) target = player.transform.position;

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed); 
    }



}
