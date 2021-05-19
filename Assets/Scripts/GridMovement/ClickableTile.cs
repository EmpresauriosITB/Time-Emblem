	using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {
	public TileState currentState;
	public Abilities currentAbility;

	public int tileX;
	public int tileY;
	public TileMap map;
	void OnMouseUp() {
        if (map.moveGraph[tileX, tileY].isActive) { 
			switch (currentState){
				case TileState.moving:
					map.GeneratePathTo(tileX, tileY); 
					break;
				case TileState.doingAbility:
					currentAbility.abilityBehaviour.doAbility(currentAbility.Power, currentAbility.isPhysical, currentAbility.areaCalculator.calculateArea(tileX, tileY, currentAbility.Area, false), map.selectedUnit);
					break;
			}
			
		}
	}

	public void AddEvents() {
		map.updateTileData += UpdateTileData;
	}

	public void UpdateTileData(GameObject go, int x, int y, TileState state, Abilities abilities) {
		if (x == tileX && y == tileY) {
			currentAbility = abilities;
			currentState = state;
			this.gameObject.GetComponent<MeshRenderer>().material = go.GetComponent<MeshRenderer>().sharedMaterial;
		}
	}
}
