using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    class EdgeProcessor : IEdgeProcessor
    {
        #region Methods

        //compares each path and finds a suitable index to insert into
        public int FindIndexToInsert(Vertex vertexToInsert, List<Vertex> pathList)
        {
            var index = 0;
            double distance = 0;
            double shortestDistance = Double.MaxValue;

            //# of loops = # of paths = pathList.Count - 1
            for (int i = 0; i<pathList.Count - 1; i++)
            {
                //getDistance from vertex to path
                distance = GetDistanceToPath(vertexToInsert, pathList[i], pathList[i + 1]);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    index = i;
                }
            }

            //check the path that closes the loop
            distance = GetDistanceToPath(vertexToInsert, pathList[pathList.Count - 1], pathList[0]);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                index = pathList.Count;
            }


            return index;
        }

        //gets the distance of a perpendicular path drawn from the startingVertex to the path created by pathPointA & pathPointB
        private double GetDistanceToPath(Vertex startingVertex, Vertex pathPointA, Vertex pathPointB)
        {
            Vertex intersect = GetIntersectionVertex(startingVertex, pathPointA, pathPointB);

            //todo: check to see if intersect is on the path, if not find closest vertex and use that as intersect
            if (CheckOnPath(intersect, pathPointA, pathPointB) == false)
            {
                //find closest vertex and set intersect = that
                double distanceA = GetPathLength(intersect, pathPointA), 
                       distanceB = GetPathLength(intersect, pathPointB);

                if (distanceA < distanceB)
                {
                    intersect = pathPointA;
                }
                else
                {
                    intersect = pathPointB;
                }
            }

            return GetPathLength(startingVertex, intersect);
        }

        //check to se is the vertexToCheck is within the domain and range of the path created by pathPointA and pathPointB
        private bool CheckOnPath(Vertex vertexToCheck, Vertex pathPointA, Vertex pathPointB)
        {
            bool isOnPath;

            if (pathPointA.x < pathPointB.x)
            {
                //ex: y = x
                if (pathPointA.y < pathPointB.y)
                {
                    if (vertexToCheck.x >= pathPointA.x && vertexToCheck.x <= pathPointB.x)
                    {
                        if (vertexToCheck.y >= pathPointA.y && vertexToCheck.y <= pathPointB.y)
                        {
                            isOnPath = true;
                        }
                        else
                        {
                            isOnPath = false;
                        }
                    }
                    else
                    {
                        isOnPath = false;
                    }

                }
                //ex: y = -x
                else
                {
                    if (vertexToCheck.x >= pathPointA.x && vertexToCheck.x <= pathPointB.x)
                    {
                        if (vertexToCheck.y <= pathPointA.y && vertexToCheck.y >= pathPointB.y)
                        {
                            isOnPath = true;
                        }
                        else
                        {
                            isOnPath = false;
                        }
                    }
                    else
                    {
                        isOnPath = false;
                    }
                }
            }
            else
            {
                //ex: y = -x
                if (pathPointA.y < pathPointB.y)
                {
                    if (vertexToCheck.x <= pathPointA.x && vertexToCheck.x >= pathPointB.x)
                    {
                        if (vertexToCheck.y >= pathPointA.y && vertexToCheck.y <= pathPointB.y)
                        {
                            isOnPath = true;
                        }
                        else
                        {
                            isOnPath = false;
                        }
                    }
                    else
                    {
                        isOnPath = false;
                    }
                }
                //ex: y = x
                else
                {
                    if (vertexToCheck.x <= pathPointA.x && vertexToCheck.x >= pathPointB.x)
                    {
                        if (vertexToCheck.y <= pathPointA.y && vertexToCheck.y >= pathPointB.y)
                        {
                            isOnPath = true;
                        }
                        else
                        {
                            isOnPath = false;
                        }
                    }
                    else
                    {
                        isOnPath = false;
                    }
                }
            }

            return isOnPath;
        }

        private double GetPathLength(Vertex pathPointA, Vertex pathPointB)
        {
            return Math.Sqrt(Math.Pow((pathPointA.x - pathPointB.x), 2)
                           + Math.Pow((pathPointA.y - pathPointB.y), 2));
        }

        private Vertex GetIntersectionVertex(Vertex startingVertex, Vertex pathPointA, Vertex pathPointB)
        {
            double pathSlope = GetSlope(pathPointA, pathPointB),
                   perpSlope = (-1 / pathSlope),
                   pathYIntersect = pathPointA.y - (pathSlope * pathPointA.x), 
                   perpYIntersect = startingVertex.y - (perpSlope * startingVertex.y);

            Vertex intersectionVertex = new Vertex();

            intersectionVertex.x = (perpYIntersect - pathYIntersect) / (pathSlope - perpSlope);
            intersectionVertex.y = (perpSlope * intersectionVertex.x) + perpSlope;
            
            return intersectionVertex;
        }

        private double GetSlope(Vertex pointA, Vertex pointB)
        {
            double mX = pointB.x - pointA.x, mY = pointB.y - pointA.y;
            
            return (mY / mX);
        }

        #endregion
    }
}
