using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.SolarSystem
{
    public class SolarSystemController : MonoBehaviour
    {
        #region SelectionManager stuff
        public GameObject currentSelected = null;
        public GameObject sidePanelController = null;
        #endregion

        /// <summary>
        /// Set in the editor.
        /// </summary>
        public GameObject satellitePrefab;

        public GameObject rootSat;  // TODO better name

        public void TestHookThing(Satellite root)
        {
            rootSat = GenerateSolarSystemFromPlanetRoot(root);
        }

        // XXX: currently properties are dynamically accessed via indirection
        //      of the Satellite class, but the structure is fixed upon generation
        public GameObject GenerateSolarSystemFromPlanetRoot(Satellite rootSatellite)
        {
            return GenerateSolarSystemHelper(null, rootSatellite);
        }

        protected GameObject GenerateSolarSystemHelper(GameObject __parent, Satellite parentSat)
        {
            var newobj = Object.Instantiate(satellitePrefab);
            var satComponent = newobj.GetComponent<PlanetComponent>();
            var childCount = parentSat.GetChildCount();

            satComponent.children = new GameObject[childCount];
            for (var i = 0; i < childCount; ++i)
            {
                satComponent.satellite = parentSat.children[i];
                satComponent.children[i] = GenerateSolarSystemHelper(newobj, parentSat.children[i]);
            }

            return newobj;
        }
    }

}