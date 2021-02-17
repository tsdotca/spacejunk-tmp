using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SpaceJunk.Model
{
    public class Orbit : Object
    {
        enum Type
        {
            Fixed,
            Elliptical,
        }
    }

    public class Offset
    {
        public int x;
        public int y;

        public Offset(int x_, int y_)
        {
            this.x = x_;
            this.y = y_;
        }
    }

    /// <summary>
    /// A celestial body that orbits another celestial body, be it artificial or natural.
    /// </summary>
    /// <remarks>
    /// Satellites have an Orbit and an offset. The Orbit determines if and how the body moves relative to its parent Satellite. The offset affects where the body is placed either in a fixed position relative to its parent or along its Orbit.
    /// </remarks>
    public class Satellite : Object
    {
        public List<Satellite> children;

        public Offset offset;
    }

}