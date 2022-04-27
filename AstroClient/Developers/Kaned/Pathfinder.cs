﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace AstroClient.Kaned
{
    internal class Pathfinder
    {
        internal static Dictionary<float, Dictionary<Vector3Int, bool>> fullGridCache = new Dictionary<float, Dictionary<Vector3Int, bool>>();

        internal Vector3[] points = null;
        internal bool foundPath = false;
        internal bool complete = false;

        internal void MultiGetPath(Vector3[] startPos, Vector3[] endPos, Action<Pathfinder, object[]> onComplete, object[][] actionArgs = null, float coarseness = 0.2f, int maxMSPerFrame = 16)
        {
            _ = MelonLoader.MelonCoroutines.Start(MPF());
            IEnumerator MPF()
            {
                bool fr = true;
                int i = 0;
                while (true)
                {
                    if (complete || fr)
                    {
                        if (i >= startPos.Length) yield break;
                        fr = false;
                        foundPath = false;
                        complete = false;
                        points = null;
                        GetPath(startPos[i], endPos[i], onComplete, actionArgs[i], coarseness, maxMSPerFrame);
                        i++;
                    }
                    yield return null;
                }
            }
        }

        internal void GetPath(Vector3 startPos, Vector3 endPos, Action<Pathfinder, object[]> onComplete = null, object[] actionArgs = null, float coarseness = 0.2f, int maxMSPerFrame = 16)
        {
            //get the grid cache if it exists and if it doesnt add it
            Dictionary<Vector3Int, bool> gridCache = null;
            if (fullGridCache.TryGetValue(coarseness, out var val))
            {
                gridCache = val;
            }
            else
            {
                gridCache = new Dictionary<Vector3Int, bool>();
                fullGridCache.Add(coarseness, gridCache);
            }
            _ = MelonLoader.MelonCoroutines.Start(Pathfind());
            IEnumerator Pathfind()
            {
                var finalmask = ~LayerMask.GetMask(new string[] { "Player", "PlayerLocal", "UiMenu" });
                startPos /= coarseness;
                endPos /= coarseness;
                endPos = new Vector3((int)endPos.x, (int)endPos.y, (int)endPos.z);

                var start = new PathingTile { pos = new Vector3Int((int)startPos.x, (int)startPos.y, (int)startPos.z) };
                var finish = new PathingTile { pos = new Vector3Int((int)endPos.x, (int)endPos.y, (int)endPos.z) };

                start.SetDistance(finish.pos);

                var activeTiles = new List<PathingTile> { start };
                var visitedTiles = new List<PathingTile>();
                activeTiles.Add(start);

                //run until the pathfinding cannot progress further
                //this happens either because it runs out of active tiles in which case it scans some and continues
                //or there is no valid path to the target

                //this weird variable is used to reduce the amount of active tiles that are checked each frame
                //otherwise the game essentially freezes
                Stopwatch sw = new Stopwatch();
                int runCount = 0;
                while (activeTiles.Count > 0)
                {
                    sw.Start();
                    activeTiles = activeTiles.OrderBy(x => x.CostDistance).ToList();
                    var checkTile = activeTiles[0];

                    if (((int)checkTile.pos.x) == ((int)finish.pos.x) && ((int)checkTile.pos.y) == ((int)finish.pos.y) && ((int)checkTile.pos.z) == ((int)finish.pos.z))
                    {
                        //Reached End

                        //indicators.ForEach(x => x.DestroyMeLocal());
                        //indicators.Clear();

                        var parent = checkTile;

                        var pPoints = new List<Vector3>();

                        while (parent != null)
                        {
                            pPoints.Insert(0, ((Vector3)parent.pos) * coarseness);
                            parent = parent.Parent;
                        }
                        points = pPoints.ToArray();
                        if (onComplete != null) onComplete(this, actionArgs);
                        foundPath = true;
                        complete = true;
                        yield break;
                    }

                    visitedTiles.Add(checkTile);
                    activeTiles.Remove(checkTile);

                    var walkableTiles = GetWalkableTiles(checkTile, finish);

                    foreach (var walkableTile in walkableTiles)
                    {
                        //We have already visited this tile so we don't need to do so again!
                        if (visitedTiles.Any(t => t.pos == walkableTile.pos)) continue;

                        //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter).
                        if (activeTiles.Any(t => t.pos == walkableTile.pos))
                        {
                            var existingTile = activeTiles.First(t => t.pos == walkableTile.pos);
                            if (existingTile.CostDistance > checkTile.CostDistance)
                            {
                                activeTiles.Remove(existingTile);
                                activeTiles.Add(walkableTile);
                            }
                        }
                        else
                        {
                            //We've never seen this tile before so add it to the list. 
                            activeTiles.Add(walkableTile);
                        }
                    }
                    //reduces lag
                    //runCount++;
                    //if (runCount >= maxIterationsPerFrame)
                    //{
                    //    runCount = 0;
                    //    yield return new WaitForEndOfFrame();
                    //}
                    if (sw.ElapsedMilliseconds > maxMSPerFrame)
                    {
                        sw.Reset();
                        yield return new WaitForEndOfFrame();
                    }
                }
                //Log.Write("Failed to find path");
                complete = true;

                List<PathingTile> GetWalkableTiles(PathingTile ct, PathingTile targetTile)
                {
                    //this is this way because i was too lazy to figure out automatic code for it     shouldn't be hard
                    var possibleTiles = new List<PathingTile>()
                    {
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y-1,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1.73f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y-1,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y-1,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1.73f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y-1,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y-1,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 1      },
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y-1,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y-1,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1.73f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y-1,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y-1,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1.73f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y  ,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y  ,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1      },
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y  ,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y  ,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 1      },
                        //new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y  ,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 0      },   //same position
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y  ,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 1      },
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y  ,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y  ,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1      },
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y  ,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y+1,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1.73f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y+1,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y+1,ct.pos.z-1), Parent = ct, Cost = ct.Cost + 1.73f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y+1,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y+1,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 1      },
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y+1,ct.pos.z  ), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x-1,ct.pos.y+1,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1.73f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x  ,ct.pos.y+1,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1.41f  },
                        new PathingTile { pos = new Vector3Int(ct.pos.x+1,ct.pos.y+1,ct.pos.z+1), Parent = ct, Cost = ct.Cost + 1.73f  },
                    };

                    possibleTiles.ForEach(tile => tile.SetDistance(targetTile.pos));
                    return possibleTiles.Where(tile => (gridCache.TryGetValue(tile.pos, out bool state) ? state : tile.pos == endPos || !Physics.CheckBox(((Vector3)tile.pos) * coarseness, Vector3.one * (coarseness / 2f), Quaternion.identity, finalmask))).ToList();
                }
            }
        }
        private class PathingTile
        {
            public Vector3Int pos;
            public float Cost; //Cost to get to this tile
            public float Distance; //Distance from the end node
            public float CostDistance => Cost + Distance;
            public PathingTile Parent = null;

            //The distance is essentially the estimated distance, ignoring walls to our target. 
            //So how many tiles left and right, up and down, ignoring walls, to get there. 
            public void SetDistance(Vector3 target)
            {
                Distance = Vector3.Distance(pos, target);
                //Distance = Mathf.Abs(target.x - pos.x) + Mathf.Abs(target.y - pos.y) + Mathf.Abs(target.z - pos.z);
            }
        }
    }
}
