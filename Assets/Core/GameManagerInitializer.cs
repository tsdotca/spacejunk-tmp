using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SpaceJunk.Core
{

    /// <summary>
    /// Initialises the GameManager from the main menu scene.
    /// </summary>
    public class GameManagerInitializer : MonoBehaviour
    {

        void Start()
        {
            GameManager.CreateFirstInstance();
            GameManager.LoadDefaults();
        }
    }

}