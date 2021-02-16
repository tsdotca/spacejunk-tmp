using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SpaceJunk.Model
{
    public class GameState
    {
        public ulong gameTime { get; private set; }

        protected PlayerInfo _playerInfo;
        protected Satellite _rootSystem;
    }

}