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
        public SpaceJunk.UI.MainMenuController MMC;

        void Start()
        {
            GameManager.CreateFirstInstance();
            GameManager.GetInstance().LoadDefaults();
            MMC.DebugDisable();
        }
    }

}