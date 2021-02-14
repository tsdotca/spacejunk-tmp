using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SpaceJunk.Model;


namespace SpaceJunk.Core
{

    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        private static PlayerInfo _playerInfo;

        public static void CreateFirstInstance()
        {
            CreateInstance();
            Reset();
        }

        public static void CreateInstance()
        {
            if (!_instance)
            {
                _instance = new GameManager();
            }
        }

        public static void LoadDefaults()
        {
            Reset();
            // open universal preferences
            // load save files and stats
        }

        protected static void Reset()
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}