using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.SolarSystem
{

    public class TestSolarSystem : MonoBehaviour
    {
        public SolarSystemController SSC;

        public const int kSolarWidth = 1024;
        public const int kSolarHeight = 768;

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
                new Orbit(0, 0)
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
                var rndplanet = new Satellite(
                    GenerateRandomPlanetName(),
                    GenerateRandomPlanetDescription(),
                    GenerateSystemOrbit()
                );
                root.children.Add(rndplanet);
            }
        }

        public static string GenerateRandomPlanetName()
        {
            // TODO this is absolute hot garbage
            string[] dummyNames = { "foo", "bar", "baz" };
            var randomNameIndex = Random.Range(0, dummyNames.Length);
            var randomName = dummyNames[randomNameIndex];
            return System.String.Format("{0}-{1} (generated satellite)",randomName, (int)Random.Range(0, 65535));
        }

        public static string GenerateRandomPlanetDescription()
        {
            return "this is a description";
        }

        public static Orbit GenerateSystemOrbit()
        {
            return new Orbit(
                Random.Range(-kSolarWidth/2, kSolarWidth/2),
                Random.Range(-kSolarHeight/2, kSolarHeight/2)
            );
        }
    }

}
