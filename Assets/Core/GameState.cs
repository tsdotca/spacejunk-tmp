using UnityEngine;

namespace SpaceJunk.Core
{
    public class GameState
    {
        public ulong gameTime = 0;

        public PlayerInfo playerInfo;

        // Tree of celestial shit
        public Satellite rootSystem;
    }
}