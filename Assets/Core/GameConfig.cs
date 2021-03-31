using System;

namespace SpaceJunk.Core
{
    [Serializable]
    public class ScreenResolution
    {
        public int w = 1024;
        public int h = 768;
    }

    [Serializable]
    public class GameConfig
    {
        public ScreenResolution resolution;
        public bool fullscreen = false;
        public int vol_music = 80;
        public int vol_sfx = 80;
    }
}