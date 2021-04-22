using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.SolarSystem
{

    public class TestSolarSystem : MonoBehaviour
    {
        public SolarSystemController SSC;

        public const int kSolarWidth = 1024;
        public const int kSolarHeight = 768;

        public const int kOffsetMax = 32;
        public const int kOffsetMin = 16;

        const int kPlanetCount = 8;

        void Start()
        {
            var rndState = GenerateRandomGameState();

            GameManager.GetInstance().state = rndState;
            SSC.TestHookThing(rndState);
        }

        public static GameState GenerateRandomGameState()
        {
            GameState state = new GameState();
            var rootSystem = new Satellite(
                GameManager.GetSystemPlotName(),
                GameManager.GetSystemDescription(),
                null//ugh
                );

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
                GenerateRandomPlanetDescription(),
                GenerateRandomCoordinates()
                );
            sat.orbit.offset = GenerateSystemOffset(kOffsetMin, kOffsetMax);
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

        public static Vector3 GenerateRandomCoordinates()
        {
            int x = Random.Range(0, kSolarWidth);
            int y = Random.Range(0, kSolarHeight);
            return new Vector3(x, y, 1);
        }
    }

}
