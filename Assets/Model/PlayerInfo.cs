using UnityEngine;

namespace SpaceJunk.Model
{

    public class PlayerInfo : Object
    {
        public string Name = "unnamed player";
        
        /// <summary>
        /// How many canadian tyre bux the player possesses.
        /// </summary>
        public int Credits = 0;

        /// <summary>
        /// How much of the computing resource the player has.
        /// </summary>
        public int Computation = 0;

        // TODO: rank, ship id, etc.
    }

}