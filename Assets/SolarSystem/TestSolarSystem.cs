using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSolarSystem : MonoBehaviour
{
    public GameObject root;
    public GameObject planetPrefab;

    public const int solar_w = 64;
    public const int solar_h = 64;

    const int planet_n = 8;

    // Start is called before the first frame update
    void Start()
    {
        // todo generate root
        for (int i = 0; i < planet_n; ++i)
        {
            int x = Random.Range(-(solar_w / 2), solar_w / 2);
            int y = Random.Range(-(solar_h / 2), solar_h / 2);

            var clone = Object.Instantiate(planetPrefab, root.transform);
            clone.transform.position += new Vector3(x, y, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
