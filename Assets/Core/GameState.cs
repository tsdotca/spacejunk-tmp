using UnityEngine;

namespace SpaceJunk.Core
{
    public class GameState
    {
        public ulong gameTime = 0;

        public PlayerInfo playerInfo;

        // Tree of celestial shit
        // TODO convert to a more efficient data structure depending on use case
        public Satellite _rootSystem;
    }
}