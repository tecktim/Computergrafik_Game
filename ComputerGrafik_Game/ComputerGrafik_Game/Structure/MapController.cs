using OpenTK.Mathematics;
using System.Collections.Generic;

namespace ComputerGrafik_Game.Structure
{
    internal class MapController
    {
        private Map way1 = new Map(new Vector2(-1.0f, -0.5f), new Vector2(0.1f, -0.5f));
        private Map way2 = new Map(new Vector2(0.1f, -0.5f), new Vector2(0.1f, 0.5f));
        private Map way3 = new Map(new Vector2(0.1f, 0.5f), new Vector2(0.75f, 0.5f));
        private Map way4 = new Map(new Vector2(0.75f, 0.5f), new Vector2(0.75f, -1.0f));



        public List<Map> buildMap()
        {
            List<Map> wayPointList = new List<Map>();
            wayPointList.Add(way1);
            wayPointList.Add(way2);
            wayPointList.Add(way3);
            wayPointList.Add(way4);
            return wayPointList;
        }
    }
}
