using System.Collections.Generic;

namespace SpaceJunk.Core
{

    public struct Orbit
    {
        public int x;
        public int y;
        //public int a;
        //public int b;

        public Orbit(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Satellite
    {
        public string name;
        public string description;
        public Orbit orbit;
        public List<Satellite> children;

        public Satellite(string name, string description, Orbit orbit)
        {
            this.name = name;
            this.description = description;
            this.orbit = orbit;
            children = new List<Satellite>(8);
        }
    }
}