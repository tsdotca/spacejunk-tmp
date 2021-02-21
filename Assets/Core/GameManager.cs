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
        /// <summary>
        /// The name of the tag used for GameObjects in the UI that are selectable by the SelectionManager class.
        /// 
        /// If you change the name of the layer in the Tags and Layers manager, you need to update it here.
        /// </summary>
        public const string SELECT_TAG_NAME = "Selectable";

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
            // TODO open universal preferences
            LoadSaveGames();
        }

        public static void LoadSaveGames()
        {

        }

        public static void Reset()
        {
        }

        public static void ChangeToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// This returns the English name of the solar system that the game takes place in.
        /// 
        /// Currently hard-coded, but may be configurable or randomly generated later on.
        /// </summary>
        public static string GetSystemPlotName()
        {
            return "Pytheas Majoris";
        }
    }

}