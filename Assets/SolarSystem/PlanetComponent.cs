using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.SolarSystem
{
    public class PlanetComponent : MonoBehaviour
    {
        public Satellite satellite;
        // TODO code duplication for Satellite children
        // TODO access protection
        public GameObject[] children;
    }
}
