using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {

	public int tileX;
	public int tileY;
	public TileMap map;

	private bool characterActive = false;
	private bool allowedToCLick = false;

	void OnMouseUp() {
		if (characterActive && allowedToCLick) { map.GeneratePathTo(tileX, tileY); }
	}

	public void AddEvents(BattleManager manager) {
		manager.setAllowedToClick += SetAllowedToClick;
		manager.setCharacterActive += SetCharacterActive;
		manager.disableAllowedToCLick += DisableAllowedToCLick;
	}

	public void SetAllowedToClick(int x, int y) {
		if ( x == tileX && y == tileY) {allowedToCLick = true; }
	}

	public void SetCharacterActive(bool flag) {
		characterActive = flag;
	}

	public void DisableAllowedToCLick() {
		allowedToCLick = false;
	}

}
