using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceJunk.UI
{

    public class MainMenuResponder : MonoBehaviour
    {
        public void OnContinuePress()
        {
            print("i am bender please insert girder");
        }

        public void OnNewGamePress()
        {
            print("hooray you want a new game");
        }

        public void OnLoadGamePress()
        {
            print("now you want to LOAD a GAME?");
        }

        public void OnOptionsPress()
        {
        }

        public void OnQuitPress()
        {
            Debug.Log("goodbye");
            Application.Quit();
        }
    }

}