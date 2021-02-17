using UnityEngine;
using UnityEngine.Assertions;

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
        // TODO need a better way of determining sanity checks
        Assert.IsNotNull(planetPrefab.GetComponent<Satellite>());

        // TODO generate the root object; it is assumed to exist within the scene

        for (int i = 0; i < planet_n; ++i)
        {
            var clone = Object.Instantiate(planetPrefab, root.transform);
            clone.transform.position += GenerateRandomObjectPosition(solar_w, solar_h);
            var sat = clone.GetComponent<Satellite>();
            sat.name = GenerateRandomPlanetName();
        }
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

    public static string GenerateRandomPlanetName()
    {
        string[] dummyNames = { "foo", "bar", "baz" };
        // TODO this is absolute hot garbage
        var randomNameIndex = Random.Range(0, dummyNames.Length);
        var randomName = dummyNames[randomNameIndex];
        return System.String.Format("{0}-{1}", randomName, (int)Random.Range(0, 65535));
    }
}
