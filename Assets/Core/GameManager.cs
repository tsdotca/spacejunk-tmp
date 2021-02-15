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