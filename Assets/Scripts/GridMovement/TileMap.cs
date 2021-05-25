using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TileMap : MonoBehaviour {

	public GameObject selectedUnit;

	public TileSet tileSet;

	public int[,] currentTiles;
	public Node[,] graph;

	public delegate void ChangeTileMaterial(GameObject go, int x, int y);
	public event ChangeTileMaterial changeTileMaterial;

	public void Init(BattleManager manager) {
        GenerateMapData();
		GenerateMapVisual(manager);
		GeneratePathfindingGraph();
	}

    public void setSelectedUnit(GameObject selectedUnit) {
        selectedUnit.GetComponent<Unit>().tileX = (int)selectedUnit.transform.position.x;
        selectedUnit.GetComponent<Unit>().tileY = (int)selectedUnit.transform.position.y;
        selectedUnit.GetComponent<Unit>().map = this;
        this.selectedUnit = selectedUnit;
        
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

	public void ActivateTile(int x, int y, bool isActive) {
		graph[x,y].isActive = isActive;
		if (isActive) { changeTileMaterial(tileSet.tileTypes[0].tileVisualPrefabActive, x, y); }
		else { changeTileMaterial(tileSet.tileTypes[0].tileVisualPrefabNotActive, x, y); }
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
		
		// Initialize the array
		graph = new Node[tileSet.GetX(),tileSet.GetY()];

		// Initialize a Node for each spot in the array
		for(int x=0; x < tileSet.GetX(); x++) {
			for(int y=0; y < tileSet.GetY(); y++) {
				graph[x,y] = new Node();
				graph[x,y].x = x;
				graph[x,y].y = y;
			}
		}

		// Now that all the nodes exist, calculate their neighbours
		for(int x=0; x < tileSet.GetX(); x++) {
			for(int y=0; y < tileSet.GetY(); y++) {

				// This is the 4-way connection version:
				if(x > 0)
					graph[x,y].neighbours.Add( graph[x-1, y] );
				if(x < tileSet.GetX()-1)
					graph[x,y].neighbours.Add( graph[x+1, y] );
				if(y > 0)
					graph[x,y].neighbours.Add( graph[x, y-1] );
				if(y < tileSet.GetY()-1)
					graph[x,y].neighbours.Add( graph[x, y+1] );


				/*
				// This is the 8-way connection version (allows diagonal movement)
				// Try left
				if(x > 0) {
					graph[x,y].neighbours.Add( graph[x-1, y] );
					if(y > 0)
						graph[x,y].neighbours.Add( graph[x-1, y-1] );
					if(y < tileSet.GetY()-1)
						graph[x,y].neighbours.Add( graph[x-1, y+1] );
				}

				// Try Right
				if(x < tileSet.GetX()-1) {
					graph[x,y].neighbours.Add( graph[x+1, y] );
					if(y > 0)
						graph[x,y].neighbours.Add( graph[x+1, y-1] );
					if(y < tileSet.GetY()-1)
						graph[x,y].neighbours.Add( graph[x+1, y+1] );
				}

				// Try straight up and down
				if(y > 0)
					graph[x,y].neighbours.Add( graph[x, y-1] );
				if(y < tileSet.GetY()-1)
					graph[x,y].neighbours.Add( graph[x, y+1] );
					*/

				// This also works with 6-way hexes and n-way variable areas (like EU4)
				
			}
		}
	}

	void GenerateMapVisual(BattleManager manager) {
		int num = 0;
		for(int x=0; x < tileSet.GetX(); x++) {
			for(int y=0; y < tileSet.GetY(); y++) {
				num ++;
				TileType tt = tileSet.tileTypes[ currentTiles[x,y] ];
				
				GameObject go = (GameObject)Instantiate( tt.tileVisualPrefabNotActive, new Vector3(x, y, 0), Quaternion.identity );
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
		return new Vector3(x, y, 0);
	}

	public bool UnitCanEnterTile(int x, int y) {

		// We could test the unit's walk/hover/fly type against various
		// terrain flags here to see if they are allowed to enter the tile.
		
		Debug.Log("ISWALKABLE: " + tileSet.tileTypes[currentTiles[x, y]].isWalkable);

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

			Debug.Log("EJECUTADO");

			Dictionary<Node, float> dist = new Dictionary<Node, float>();
            Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

            // Setup the "Q" -- the list of nodes we haven't checked yet.
            List<Node> unvisited = new List<Node>();

            Node source = graph[
								gameObjectToMove.GetComponent<Unit>().tileX,
								gameObjectToMove.GetComponent<Unit>().tileY
                                ];
			 
            Node target = graph[
                                x,
                                y
                                ];

			dist[source] = 0;
            prev[source] = null;

            // Initialize everything to have INFINITY distance, since
            // we don't know any better right now. Also, it's possible
            // that some nodes CAN'T be reached from the source,
            // which would make INFINITY a reasonable value
            foreach (Node v in graph)
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
			Debug.Log("X: " + currentPath[currentPath.Count -1].x + "Y: " + currentPath[currentPath.Count - 1].y);
        }
	}

}
