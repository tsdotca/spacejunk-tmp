namespace SpaceJunk.Core
{
    /// <summary>
    /// Gross god-class that strings together things whilst one figures this out.
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Steps from time zero, representing the number of months in Sol units.
        /// </summary>
        public ulong gameTime = 0;

        public PlayerInfo playerInfo;

        // Tree of celestial shit
        public Satellite rootSystem;
    }
}