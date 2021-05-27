using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TileMap : MonoBehaviour {

	public GameObject selectedUnit;

	public TileSet tileSet;

	public int[,] currentTiles;
	public Node[,] moveGraph;
	public Node[,] abilityGraph;

    public bool activevate = false;
    private List<GameObject> enemies;
	

	public delegate void UpdateTileData(GameObject go, int x, int y, TileState state, Abilities abilities);
	public event UpdateTileData updateTileData;

	public void Init(BattleManager manager) {
        GenerateMapData();
		GenerateMapVisual(manager);
		GeneratePathfindingGraph();
        GenerateEnemies();
	}

    public void setSelectedUnit(GameObject selectedUnit) {
        selectedUnit.GetComponent<Unit>().tileX = (int)selectedUnit.transform.position.x;
        selectedUnit.GetComponent<Unit>().tileY = (int)selectedUnit.transform.position.z;
        selectedUnit.GetComponent<Unit>().map = this;
        this.selectedUnit = selectedUnit;
    }

    public void GenerateEnemies() {
        enemies = new List<GameObject>();
        for (int i = 0; i < tileSet.enemyTeam.enemies.Count; i++) {
            EnemyData d = tileSet.enemyTeam.enemies[i];
            Vector3 v = new Vector3(d.initX, d.enemy.transform.position.y, d.initY);
            Transform t = d.enemy.transform;
            t.position = v;
            OccupyTile(d.initX,d.initY);
            GameObject go = GameObject.Instantiate(d.enemy, t);

            go.transform.parent = this.gameObject.transform.parent.GetChild(0).GetChild(1);
            enemies.Add(d.enemy);
        }
    }

    public List<GameObject> getEnemies() {
        return enemies;
    }

	public void OccupyTile(int x, int y) {
		currentTiles[x, y] = 1;
	}

	public void DesocupyTile(int x, int y) {
		bool flag = true;
		for (int i = 0; i < tileSet.tileMapData.Length && flag; i++) {
			if (tileSet.tileMapData[i].posX == x && tileSet.tileMapData[i].posY == y) {
				flag = false;
				currentTiles[x, y] = tileSet.tileMapData[i].tileType;
			} 
		}
	} 

	public void ActivateTile(int x, int y, bool isActive, TileState state, Abilities abilities) {
		moveGraph[x,y].isActive = isActive;
		GameObject visualPrefab = null;
		switch (state) {
			case TileState.doingAbility:
				visualPrefab = tileSet.tileTypes[0].tileVisualPrefabActive;
				break;
			case TileState.moving:
				visualPrefab = tileSet.tileTypes[0].tileVisualPrefabActive;
				break;
			case TileState.nothing:
				visualPrefab = tileSet.tileTypes[0].tileVisualPrefabNotActive;
				break;
		}
		updateTileData(visualPrefab, x, y, state, abilities);
	}


	public bool isWalkable (int x, int y) {
		return tileSet.tileTypes[currentTiles[x,y]].isWalkable;
	}

	void GenerateMapData() {
		// Allocate our map tiles
		currentTiles = new int[tileSet.GetX(),tileSet.GetY()];
		
		for (int i = 0; i < tileSet.tileMapData.Length; i++) {
            currentTiles[tileSet.tileMapData[i].posX, tileSet.tileMapData[i].posY] = tileSet.tileMapData[i].tileType;
        }
		

	}

	public float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY) {

		TileType tt = tileSet.tileTypes[ currentTiles[targetX,targetY] ];

		if(UnitCanEnterTile(targetX, targetY) == false)
			return Mathf.Infinity;

		float cost = tt.movementCost;

		if( sourceX!=targetX && sourceY!=targetY) {
			// We are moving diagonally!  Fudge the cost for tie-breaking
			// Purely a cosmetic thing!
			cost += 0.001f;
		}

		return cost;

	}

	void GeneratePathfindingGraph() {
		moveGraph = PathFindingGraphGenerator.generateNoCardinals(tileSet.GetX(),tileSet.GetY());
		abilityGraph = PathFindingGraphGenerator.generateCardinals(tileSet.GetX(),tileSet.GetY());
	}

	void GenerateMapVisual(BattleManager manager) {
		int num = 0;
		for(int x=0; x < tileSet.GetX(); x++) {
			for(int y=0; y < tileSet.GetY(); y++) {
				num ++;
				TileType tt = tileSet.tileTypes[ currentTiles[x,y] ];
				
				GameObject go = (GameObject)Instantiate( tt.tileVisualPrefabNotActive, new Vector3(x, 0, y), Quaternion.identity );
				go.name = "Tile " + num;
				go.transform.parent = this.gameObject.transform.GetChild(0).transform;

				ClickableTile ct = go.GetComponent<ClickableTile>();
				ct.tileX = x;
				ct.tileY = y;
				ct.map = this;
				ct.AddEvents();
			}
		}
	}

	public Vector3 TileCoordToWorldCoord(int x, int y) {
		return new Vector3(x, 1.5f, y);
	}

	public bool UnitCanEnterTile(int x, int y) {

		// We could test the unit's walk/hover/fly type against various
		// terrain flags here to see if they are allowed to enter the tile.
		
		//Debug.Log("ISWALKABLE: " + tileSet.tileTypes[currentTiles[x, y]].isWalkable);

		return tileSet.tileTypes[currentTiles[x,y] ].isWalkable;
	}

	public void GeneratePathTo(int x, int y, GameObject gameObject) {
		GameObject gameObjectToMove;
		if (gameObject != null)
		{
			gameObjectToMove = gameObject;
		}
		else if (selectedUnit != null)
		{
			gameObjectToMove = selectedUnit;
		}
		else gameObjectToMove = null;
		if (gameObjectToMove != null)
        {
			// Clear out our unit's old path.
			gameObjectToMove.GetComponent<Unit>().currentPath = null;
			//Debug.Log("GENERATEPATH - X & Y: " + x + " - " + y);
			if (UnitCanEnterTile(x, y) == false)
            {
                // We probably clicked on a mountain or something, so just quit out.
                return;
            }

			//Debug.Log("EJECUTADO");

			Dictionary<Node, float> dist = new Dictionary<Node, float>();
            Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

            // Setup the "Q" -- the list of nodes we haven't checked yet.
            List<Node> unvisited = new List<Node>();

            Node source = moveGraph[
                                selectedUnit.GetComponent<Unit>().tileX,
                                selectedUnit.GetComponent<Unit>().tileY
                                ];

            Node target = moveGraph[
                                x,
                                y
                                ];

			dist[source] = 0;
            prev[source] = null;

            // Initialize everything to have INFINITY distance, since
            // we don't know any better right now. Also, it's possible
            // that some nodes CAN'T be reached from the source,
            // which would make INFINITY a reasonable value
            foreach (Node v in moveGraph)
            {
                if (v != source)
                {
                    dist[v] = Mathf.Infinity;
                    prev[v] = null;
                }

                unvisited.Add(v);
            }

            while (unvisited.Count > 0)
            {
                // "u" is going to be the unvisited node with the smallest distance.
                Node u = null;

                foreach (Node possibleU in unvisited)
                {
                    if (u == null || dist[possibleU] < dist[u])
                    {
                        u = possibleU;
                    }
                }

                if (u == target)
                {
                    break;  // Exit the while loop!
                }

                unvisited.Remove(u);

                foreach (Node v in u.neighbours)
                {
                    //float alt = dist[u] + u.DistanceTo(v);
                    float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                    }
                }
            }

            // If we get there, the either we found the shortest route
            // to our target, or there is no route at ALL to our target.

            if (prev[target] == null)
            {
                // No route between our target and the source
                return;
            }

            List<Node> currentPath = new List<Node>();

            Node curr = target;

            // Step through the "prev" chain and add it to our path
            while (curr != null)
            {
                currentPath.Add(curr);
                curr = prev[curr];
            }

            // Right now, currentPath describes a route from out target to our source
            // So we need to invert it!

            currentPath.Reverse();
			

			gameObjectToMove.GetComponent<Unit>().currentPath = currentPath;
			//Debug.Log("X: " + currentPath[currentPath.Count -1].x + "Y: " + currentPath[currentPath.Count - 1].y);
        }
	}

}
