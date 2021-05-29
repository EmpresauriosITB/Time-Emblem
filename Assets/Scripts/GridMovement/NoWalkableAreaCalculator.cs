using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWalkableAreaCalculator : MonoBehaviour {

    public ClickableTile tile;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Ha entrado");
        if (other.gameObject.tag == "Collide") {
            tile.map.currentTiles[tile.tileX, tile.tileY] = 1;
        }
    }

}
