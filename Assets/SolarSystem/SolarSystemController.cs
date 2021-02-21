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

        public GameObject rootSatellite;  // TODO better name

        public void TestHookThing(Satellite root)
        {
            rootSatellite = GenerateSolarSystemFromPlanetRoot(root);
        }

        // XXX: currently properties are dynamically accessed via indirection
        //      of the Satellite class, but the structure is fixed upon generation
        public GameObject GenerateSolarSystemFromPlanetRoot(Satellite rootSatellite)
        {
            var root = Object.Instantiate(satellitePrefab);
            
            return root;
        }

        protected GameObject GenerateSolarSystemHelper(GameObject parent, Satellite parentSat)
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