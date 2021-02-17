using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using SpaceJunk.Model;


namespace SpaceJunk.Core
{
    public class SaveGame
    {
        public string name = "<save game>";
    }

    /// <summary>
    /// here is the gross god class until things can be refactored
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// The name of the tag used for GameObjects in the UI that are selectable by the SelectionManager class.
        /// 
        /// If you change the name of the layer in the Tags and Layers manager, you need to update it here.
        /// </summary>
        public const string SELECT_TAG_NAME = "Selectable";

        private static GameManager _instance;
        //private static List<SaveGame> _saveGames;

        // TODO: cleanup
        public GameManager GetInstance()
        {
            CreateInstance();
            return _instance;
        }

        public static void CreateFirstInstance()
        {
            CreateInstance();
            Reset();
        }

        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
        }

        public static void LoadDefaults()
        {
            Reset();
            // open universal preferences
            LoadSaveGames();
        }

        public static void LoadSaveGames()
        {

        }

        public static void Reset()
        {
            //_playerInfo = new PlayerInfo();
            //_saveGames = new List<SaveGame>();
        }

        public static void ChangeToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}