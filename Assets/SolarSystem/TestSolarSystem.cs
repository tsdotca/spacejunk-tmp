using UnityEngine;
using UnityEngine.Assertions;

using SpaceJunk.Core;
using SpaceJunk.Model;

public class TestSolarSystem : MonoBehaviour
{
    public GameObject root;
    public GameObject planetPrefab;

    public const int solar_w = 64;
    public const int solar_h = 64;

    const int planet_n = 8;

    void Start()
    {
        // TODO generate the root object; it is assumed to exist within the scene

        GameManager.GetInstance().state = GenerateRandomGameState();
    }

    /// <summary>
    /// Generates a random Vector3 bounded by w, h, z=1
    /// </summary>
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
        return new Offset(x, y);
    }

    public static GameState GenerateRandomGameState()
    {
        GameState state = new GameState();
        var rootSystem = state._rootSystem;

        for (int i = 0; i < planet_n; ++i)
        {
            var rndplanet = GenerateRandomPlanet();
            rootSystem.children.Add(rndplanet);
        }

        return state;
    }

    public static Satellite GenerateRandomPlanet()
    {
        var sat = Object.Instantiate();
        sat.name = GenerateRandomPlanetName();
        sat.orbit.offset = GenerateSystemOffset(64, 64); // TODO hardcoded
        return sat;
    }

    public static string GenerateRandomPlanetName()
    {
        string[] dummyNames = { "foo", "bar", "baz" };
        // TODO this is absolute hot garbage
        var randomNameIndex = Random.Range(0, dummyNames.Length);
        var randomName = dummyNames[randomNameIndex];
        return System.String.Format("{0}-{1}", randomName, (int)Random.Range(0, 65535));
    }
}
