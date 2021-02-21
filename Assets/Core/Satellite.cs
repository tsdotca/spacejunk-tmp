using System.Collections.Generic;

namespace SpaceJunk.Core
{
    public class Offset
    {
        public int x;
        public int y;

        public Offset(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Orbit
    {
        public enum OrbitType
        {
            Fixed,
            Elliptical,
        }

        public OrbitType orbitType = OrbitType.Fixed;
        public Offset offset = new Offset(0, 0);
    }

    /// <summary>
    /// A celestial body that orbits another celestial body, be it artificial or natural.
    /// </summary>
    /// <remarks>
    /// Satellites have an Orbit and an offset. The Orbit determines if and how the body moves relative to its parent Satellite. The offset affects where the body is placed either in a fixed position relative to its parent or along its Orbit.
    /// </remarks>
    public class Satellite
    {
        public string name;
        public List<Satellite> children;
        public Orbit orbit;

        public Satellite(string name)
        {
            this.name = name;
            this.children = new List<Satellite>(8);
            this.orbit = new Orbit();
        }

        // TODO: readonly??? "is not valid for this item"
        public int GetChildCount()
        {
            return this.children.Count;
        }
    }
}