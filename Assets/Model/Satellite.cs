using System.Collections.Generic;

using UnityEngine;

namespace SpaceJunk.Model
{
    public class Offset : MonoB
    {
        public int x;
        public int y;

        public Offset(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Orbit : MonoBehaviour
    {
        enum Type
        {
            Fixed,
            Elliptical,
        }

        public Offset offset;
    }

    /// <summary>
    /// A celestial body that orbits another celestial body, be it artificial or natural.
    /// </summary>
    /// <remarks>
    /// Satellites have an Orbit and an offset. The Orbit determines if and how the body moves relative to its parent Satellite. The offset affects where the body is placed either in a fixed position relative to its parent or along its Orbit.
    /// </remarks>
    public class Satellite : MonoBehaviour
    {
        public List<Satellite> children;
        public Orbit orbit;
    }
}