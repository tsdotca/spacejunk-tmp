using UnityEngine;
using UnityEngine.InputSystem;

using SpaceJunk.Core;
using SpaceJunk.UI;

namespace SpaceJunk.SolarSystem
{
    public class SolarSystemController : MonoBehaviour
    {
        public Camera mainCamera;
        public SidePanelController sidePanelController;
        public TopMenubarController topBarController;

        public GameObject satellitePrefab;
        public Sprite rootSprite;  // FIXME do we really have to hook this up in the editor?

        protected GameObject rootSat;  // TODO better name
        protected GameObject currentSelected = null;

        public void TestHookThing(GameState gameState)
        {
            rootSat = GenerateSolarSystemFromPlanetRoot(gameState.rootSystem);
            sidePanelController.RefreshSidePanel();
            topBarController.UpdateGameStatus(gameState);
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
            newobj.name = "Generated Satellite " + sat.name;
            if (parent)
                newobj.transform.parent = parent.GetComponent<Transform>();

            newobj.transform.Translate(sat.orbit.offset.x, sat.orbit.offset.y, 0f);

            var satComponent = newobj.GetComponent<PlanetComponent>();
            satComponent.satellite = sat;

            var childCount = sat.children.Count;
            satComponent.children = new GameObject[childCount];
            for (var i = 0; i < childCount; ++i)
            {
                satComponent.children[i] = GenerateSolarSystemHelper(newobj, sat.children[i]);
            }

            return newobj;
        }

        public void OnClick()
        {
            var x = Mouse.current.position.x.ReadValue();
            var y = Mouse.current.position.y.ReadValue();

            var vect = mainCamera.ScreenToWorldPoint(new Vector3(x, y, 0));
            var x2 = vect.x;
            var y2 = vect.y;
            Debug.Log($"OnClick mouse=({x}, {y}), screen=({x2}, {y2})");

            var planet = FindPlanetAtPoint(x2, y2);
            if (planet)
                sidePanelController.SelectPlanet(planet);
            else
                sidePanelController.ClearSelection();
        }

        protected PlanetComponent FindPlanetAtPoint(float x, float y)
        {
            var contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(GameManager.GetSelectableLayerMask());
            contactFilter.NoFilter();

            // FIXME this is kind of stupid and broken:
            //     "The array to receive results. The size of the array determines
            //      the maximum number of results that can be returned."
            // so need to figure out a better way, it would seem
            const int result_limit_size = 4;
            var results = new RaycastHit2D[result_limit_size];

            if (Physics2D.Raycast(new Vector2(x, y), -Vector2.up, contactFilter, results) is int numResults && 0 < numResults)
            {
                if (1 < numResults)
                    Debug.LogWarning($"more than one click result; found {numResults}. discarding");

                var gameobj = results[0].collider.gameObject;
                if (gameobj == null)
                {
                    Debug.LogWarning("failed attempt");
                    return null;
                }

                var sat = gameobj.GetComponent<PlanetComponent>();
                return sat;
            }

            Debug.Log("nothing found");
            return null;
        }
    }
}