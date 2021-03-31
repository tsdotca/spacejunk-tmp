using UnityEngine.SceneManagement;

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
        protected static GameManager _instance;
        //private static List<SaveGame> _saveGames;

        // TODO make protected and set up proper workflow
        public GameState state;

        // TODO: cleanup
        public static GameManager GetInstance()
        {
            CreateInstance();
            return _instance;
        }

        public static void CreateFirstInstance()
        {
            CreateInstance();
            _instance.Reset();
        }

        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
        }

        public void LoadDefaults()
        {
            Reset();
            // TODO open universal preferences
            LoadSaveGames();
        }

        public static void LoadSaveGames()
        {

        }

        public void Reset()
        {
        }

        public void ChangeToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// Currently hard-coded in English, but may be configurable or randomly generated later on.
        /// </summary>
        public static string GetSystemPlotName()
        {
            return "Pytheas Majoris";
        }

        /// <summary>
        /// Currently hard-coded in English, but may be configurable or randomly generated later on.
        /// </summary>
        public static string GetSystemDescription()
        {
            return "A place where things exist!";
        }

        public static int GetSelectableLayerMask()
        {
            return 1 << 8;
        }
    }

}