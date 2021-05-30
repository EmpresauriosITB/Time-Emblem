using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingGraphGenerator {
    
    public static Node[,] generateNoCardinals(int tilex, int tiley) {
        Node[,] graph = inialize(tilex, tiley);
        for(int x=0; x < tilex; x++) {
			for(int y=0; y < tiley; y++) {

				// This is the 4-way connection version:
				if(x > 0)
					graph[x,y].neighbours.Add( graph[x-1, y] );
				if(x < tilex-1)
					graph[x,y].neighbours.Add( graph[x+1, y] );
				if(y > 0)
					graph[x,y].neighbours.Add( graph[x, y-1] );
				if(y < tiley-1)
					graph[x,y].neighbours.Add( graph[x, y+1] );
            }
        }
        return graph;
    }

    public static Node[,] generateCardinals(int tilex, int tiley) {
        Node[,] graph = inialize(tilex, tiley);
        for(int x=0; x < tilex; x++) {
            for(int y=0; y < tiley; y++) {
                if(x > 0) {
					graph[x,y].neighbours.Add( graph[x-1, y] );
					if(y > 0)
						graph[x,y].neighbours.Add( graph[x-1, y-1] );
					if(y < tiley-1)
						graph[x,y].neighbours.Add( graph[x-1, y+1] );
				}

				if(x < tilex-1) {
					graph[x,y].neighbours.Add( graph[x+1, y] );
					if(y > 0)
						graph[x,y].neighbours.Add( graph[x+1, y-1] );
					if(y < tiley-1)
						graph[x,y].neighbours.Add( graph[x+1, y+1] );
				}

				if(y > 0)
					graph[x,y].neighbours.Add( graph[x, y-1] );
				if(y < tiley-1)
					graph[x,y].neighbours.Add( graph[x, y+1] );
            }
        }
        return graph;
    }

    private static Node[,] inialize(int tilex, int tiley) {
        Node[,] graph = new Node[tilex, tiley];
        for(int x=0; x < tilex; x++) {
			for(int y=0; y < tiley; y++) {
				graph[x,y] = new Node();
				graph[x,y].x = x;
				graph[x,y].y = y;
			}
		}
        return graph;
    }
}
