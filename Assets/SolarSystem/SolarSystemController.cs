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

        // hooked up in the editor because aarrarhghghh
        public Sprite rootSprite;

        public void TestHookThing(Satellite root)
        {
            rootSat = GenerateSolarSystemFromPlanetRoot(root);
        }

        // XXX: currently properties are dynamically accessed via indirection
        //      of the Satellite class, but the structure is fixed upon generation
        public GameObject GenerateSolarSystemFromPlanetRoot(Satellite rootSatellite)
        {
            var root = GenerateSolarSystemHelper(null, rootSatellite);
            root.GetComponent<SpriteRenderer>().sprite = rootSprite;
            return root;
        }

        protected GameObject GenerateSolarSystemHelper(GameObject parent, Satellite parentSat)
        {
            var newobj = Object.Instantiate(satellitePrefab);
            newobj.name = "Generated Satellite";
            newobj.GetComponent<Transform>().Translate(parentSat.orbit.offset.x, parentSat.orbit.offset.y, 0f);
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