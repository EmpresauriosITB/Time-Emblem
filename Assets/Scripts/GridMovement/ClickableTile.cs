using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {
	public TileState currentState;

	public int tileX;
	public int tileY;
	public TileMap map;
	void OnMouseUp() {
        if (map.graph[tileX, tileY].isActive) { 
			switch (currentState){
				case TileState.moving:
					map.GeneratePathTo(tileX, tileY); 
					break;
				case TileState.doingAbility:
					Debug.Log("Doing Ability");
					break;
			}
			
		}
	}

	public void AddEvents() {
		map.changeTileMaterial += ChangeMaterial;
	}

	public void ChangeMaterial(GameObject go, int x, int y, TileState state) {
		if (x == tileX && y == tileY) {
			currentState = state;
			this.gameObject.GetComponent<MeshRenderer>().material = go.GetComponent<MeshRenderer>().sharedMaterial;
		}
	}
}
