using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

using SpaceJunk.Core;
using SpaceJunk.UI;

namespace SpaceJunk.SolarSystem
{
    public class SolarSystemController : MonoBehaviour
    {
        public Camera mainCamera;
        public TopMenubarController topBarController;
        public InfoPanelController infoPanelController;

        public GameObject satellitePrefab;
        public Sprite rootSprite;  // FIXME do we really have to hook this up in the editor?

        protected GameObject rootSat;  // TODO better name

        private void Start()
        {
        }

        public void TestHookThing(GameState gameState)
        {
            rootSat = GenerateSolarSystemFromPlanetRoot(gameState.rootSystem);
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
            newobj.name = sat.name;
            if (parent)
                newobj.transform.parent = parent.GetComponent<Transform>();

            newobj.transform.Translate(sat.orbit.x, sat.orbit.y, 0f);
            newobj.transform.localScale = new Vector3(4, 4, 1);

            var satComponent = newobj.GetComponent<SatelliteComponent>();
            satComponent.satellite = sat;

            var childCount = sat.children.Count;
            satComponent.children = new GameObject[childCount];
            for (var i = 0; i < childCount; ++i)
            {
                satComponent.children[i] = GenerateSolarSystemHelper(newobj, sat.children[i]);
            }

            return newobj;
        }

        public void OnClick(CallbackContext ctx)
        {
            if (ctx.phase != InputActionPhase.Performed)
                return;

            float x = Mouse.current.position.x.ReadValue();
            float y = Mouse.current.position.y.ReadValue();

            var vect = mainCamera.ScreenToWorldPoint(new Vector3(x, y, 0));
            float x2 = vect.x;
            float y2 = vect.y;
            Debug.Log($"OnClick mouse=({x}, {y}), screen=({x2}, {y2})");

            var planet = FindPlanetAtPoint(x2, y2);
            if (planet)
            {
                infoPanelController.Select(planet.satellite);
            }
            else
            {
                print("oops nothing");
                infoPanelController.Disable();
            }
        }

        protected SatelliteComponent FindPlanetAtPoint(float x, float y)
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

                var sat = gameobj.GetComponent<SatelliteComponent>();
                return sat;
            }

            return null;
        }
    }
}