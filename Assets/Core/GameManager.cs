namespace SpaceJunk.Core
{
    /// <summary>
    /// here is the gross god class until things can be refactored
    /// </summary>
    public class GameManager
    {
        protected static GameManager _instance;

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
            // TODO open universal preferences
            LoadSaveGames();
        }

        public static void LoadSaveGames()
        {

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