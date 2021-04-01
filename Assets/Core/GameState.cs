namespace SpaceJunk.Core
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    /// <summary>
    /// This class represents a given state of the player's progress: health, resources, etc.
    /// </summary>
    public class PlayerInfo
    {
        public string Name = "unnamed player";

        // TODO: rank, ship id, etc.
    }

    /// <summary>
    /// Gross god-class that strings together things whilst one figures this out.
    /// </summary>
    public class GameState
    {
        public Difficulty difficulty = Difficulty.Normal;

        /// <summary>
        /// Steps from time zero, representing the number of months in Sol units.
        /// </summary>
        public ulong gameTime = 0;

        /// <summary>
        /// The player's minor details (name, pronouns, etc).
        /// </summary>
        public PlayerInfo playerInfo;

        /// <summary>
        /// How many canadian tyre bux the player possesses.
        /// </summary>
        public int Credits = 0;

        /// <summary>
        /// How much of the computing resource the player has.
        /// </summary>
        public int Computation = 0;

        /// <summary>
        /// The root of the solar system, either pre-computed or generated.
        /// </summary>
        public Satellite rootSystem;
    }
}