using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileType {

	public string name;
	public GameObject tileVisualPrefabNotActive;
	public GameObject tileVisualPrefabActive;

	public bool isWalkable = true;
	public float movementCost = 1;
}
