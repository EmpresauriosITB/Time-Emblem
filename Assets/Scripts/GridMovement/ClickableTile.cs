using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {

	public int tileX;
	public int tileY;
	public TileMap map;

	private bool characterActive = false;
	private bool allowedToCLick = false;

	void OnMouseUp() {
		Debug.Log("Debug: " + map.graph[tileX, tileY].isActive);
        if (map.graph[tileX, tileY].isActive) { 
			map.GeneratePathTo(tileX, tileY); 
		}
	}

	public void AddEvents() {
		map.changeTileMaterial += ChangeMaterial;
	}

	public void ChangeMaterial(GameObject go, int x, int y) {
		if (x == tileX && y == tileY) {
			this.gameObject.GetComponent<MeshRenderer>().material = go.GetComponent<MeshRenderer>().sharedMaterial;
		}
	}

}
