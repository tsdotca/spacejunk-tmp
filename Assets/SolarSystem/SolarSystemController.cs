using UnityEngine;
using UnityEngine.InputSystem;

using SpaceJunk.Core;

namespace SpaceJunk.SolarSystem
{
    public class SolarSystemController : MonoBehaviour
    {
        public GameObject currentSelected = null;
        public GameObject sidePanelController = null;

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

        protected GameObject GenerateSolarSystemHelper(GameObject parent, Satellite sat)
        {
            var newobj = Object.Instantiate(satellitePrefab);
            newobj.name = "Generated Satellite";
            if (parent)
                newobj.GetComponent<Transform>().parent = parent.GetComponent<Transform>();
            newobj.GetComponent<Transform>().Translate(sat.orbit.offset.x, sat.orbit.offset.y, 0f);
            var satComponent = newobj.GetComponent<PlanetComponent>();

            var childCount = sat.GetChildCount();
            satComponent.children = new GameObject[childCount];
            for (var i = 0; i < childCount; ++i)
            {
                satComponent.satellite = sat.children[i];
                satComponent.children[i] = GenerateSolarSystemHelper(newobj, sat.children[i]);
            }

            return newobj;
        }

        // this needs to be moved to a sane place
        public void OnPrimaryClick(InputAction.CallbackContext context)
        {
            var hit = Physics2D.Raycast(transform.position, -Vector2.up);

            if (hit.collider)
            {
                Debug.Log("you clicked on something!");
            }
        }
    }
}