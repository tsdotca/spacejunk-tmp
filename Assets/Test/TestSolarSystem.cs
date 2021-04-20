using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.SolarSystem
{

    public class TestSolarSystem : MonoBehaviour
    {
        public GameObject SSC;

        public const int kSolarWidth = 64;
        public const int kSolarHeight = 64;

        const int kPlanetCount = 8;

        void Start()
        {
            var rndState = GenerateRandomGameState();

            GameManager.GetInstance().state = rndState;
            var comp = SSC.GetComponent<SolarSystemController>();
            comp.TestHookThing(rndState);
        }

        public static GameState GenerateRandomGameState()
        {
            GameState state = new GameState();
            var rootSystem = new Satellite(
                GameManager.GetSystemPlotName(),
                GameManager.GetSystemDescription());

            GenerateSolarSystem(rootSystem);
            state.rootSystem = rootSystem;

            return state;
        }

        // TODO: remove in-out param
        public static void GenerateSolarSystem(Satellite root)
        {
            for (int i = 0; i < kPlanetCount; ++i)
            {
                var rndplanet = GenerateRandomPlanet();
                root.children.Add(rndplanet);
            }
        }

        public static Satellite GenerateRandomPlanet()
        {
            var sat = new Satellite(
                GenerateRandomPlanetName(),
                GenerateRandomPlanetDescription()
                );
            sat.orbit.offset = GenerateSystemOffset(kSolarWidth, kSolarHeight);
            return sat;
        }

        public static string GenerateRandomPlanetName()
        {
            // TODO this is absolute hot garbage
            string[] dummyNames = { "foo", "bar", "baz" };
            var randomNameIndex = Random.Range(0, dummyNames.Length);
            var randomName = dummyNames[randomNameIndex];
            return System.String.Format("{0}-{1}", randomName, (int)Random.Range(0, 65535));
        }

        public static string GenerateRandomPlanetDescription()
        {
            return "this is a description";
        }

        public static Vector3 GenerateRandomObjectPosition(int w, int h)
        {
            int x = Random.Range(-(w / 2), w / 2);
            int y = Random.Range(-(h / 2), h / 2);
            return new Vector3(x, y, 1);
        }

        public static Offset GenerateSystemOffset(int w, int h)
        {
            int x = Random.Range(-(w / 2), w / 2);
            int y = Random.Range(-(h / 2), h / 2);
            return new Offset();
        }
    }

}
