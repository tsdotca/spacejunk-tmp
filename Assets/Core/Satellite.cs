using System.Collections.Generic;

namespace SpaceJunk.Core
{
    public struct Offset
    {
        public int x;
        public int y;
    }

    public class Orbit
    {
        public enum OrbitType
        {
            Fixed,
            Elliptical,
        }

        public OrbitType orbitType = OrbitType.Fixed;
        public Offset offset;
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
        public string description;
        public List<Satellite> children;
        public Orbit orbit;

        public Satellite(string name, string description)
        {
            this.name = name;
            this.description = description;
            children = new List<Satellite>(8);
            orbit = new Orbit();
        }
    }
}