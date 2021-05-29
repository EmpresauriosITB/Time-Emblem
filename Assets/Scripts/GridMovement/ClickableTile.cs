using UnityEngine;
using System.Collections;


public class ClickableTile : MonoBehaviour {
	public TileState currentState;
	public Abilities currentAbility;

	public int tileX;
	public int tileY;
	public TileMap map;

	void OnMouseUp() {
		Debug.Log("ha clicao");
		if (map.activevate) {
            switch (currentState) {
                case TileState.moving:
                    if (map.moveGraph[tileX, tileY].isActive) {
                        map.GeneratePathTo(tileX, tileY, null);
                    }
                    break;
                case TileState.doingAbility:
                    InstanceAbilityData.doAbility(tileX, tileY, false, map.selectedUnit);
                    break;
            }
		}
	}

	public void AddEvents() {
		map.updateTileData += UpdateTileData;
	}

	public void UpdateTileData(GameObject go, int x, int y, TileState state, Abilities abilities) {
		if (x == tileX && y == tileY) {
			currentState = state;
            if (currentState == TileState.doingAbility) {
                currentAbility = abilities;
                InstanceAbilityData.instanceAbility(abilities, map, this);
            }
			this.gameObject.GetComponent<MeshRenderer>().material = go.GetComponent<MeshRenderer>().sharedMaterial;
		}
	}
}
