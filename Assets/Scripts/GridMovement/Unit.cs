using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

	public int tileX;
	public int tileY;
	public TileMap map;

	public List<Node> currentPath = null;
	float moveSpeed;
	 
	void Start() {
		moveSpeed = this.gameObject.GetComponent<CharacterUnitController>().character.stats.gridSpeed;
		tileX = (int) this.transform.position.x;
		tileY = (int) this.transform.position.z;
		if (!this.gameObject.GetComponent<CharacterUnitController>().isPlayer)
		{
			map = this.gameObject.GetComponent<CharacterUnitController>().map;
		}	
		
	}

	void Update() {
		if(currentPath != null) {

			int currNode = 0;

			while( currNode < currentPath.Count-1 ) {

				Vector3 start = map.TileCoordToWorldCoord( currentPath[currNode].x, currentPath[currNode].y ) + 
					new Vector3(0, -1f, 0) ;
				Vector3 end   = map.TileCoordToWorldCoord( currentPath[currNode+1].x, currentPath[currNode+1].y )  + 
					new Vector3(0, -1f, 0) ;

				Debug.DrawLine(start, end, Color.red);

				currNode++;
			}
		}
	}




	public void MoveNextTile() {
		float remainingMovement = moveSpeed;

		map.DesocupyTile(tileX, tileY);
        if (this.gameObject.GetComponent<CharacterUnitController>().isPlayer)
        {
            PathFind.setAllowedToCLickTiles(moveSpeed, tileX, tileY, false, map, TileState.nothing, null);
        }

        while (remainingMovement > 0 && currentPath != null) {

			// Get cost from current tile to next tile
			remainingMovement -= map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y );

			// Move us to the next tile in the sequence
			tileX = currentPath[1].x;
			tileY = currentPath[1].y;

			transform.position = map.TileCoordToWorldCoord( tileX, tileY );	// Update our unity world position

			// Remove the old "current" tile
			currentPath.RemoveAt(0);

			if(currentPath.Count == 1) {
				// We only have one tile left in the path, and that tile MUST be our ultimate
				// destination -- and we are standing on it!
				// So let's just clear our pathfinding info.
				currentPath = null;
			}
		}

		map.OccupyTile(tileX, tileY);
		if(this.gameObject.GetComponent<CharacterUnitController>().isPlayer){
			PathFind.setAllowedToCLickTiles(moveSpeed, tileX, tileY, true, map, TileState.moving, null);
		}	
        this.gameObject.GetComponent<CharacterUnitController>().actionsLeft --;
    }
}
