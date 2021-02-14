using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;

using SpaceJunk.Core;

namespace SpaceJunk.UI
{

    public class MainMenuController : MonoBehaviour
    {
        public Canvas newGameCanvas;

        public Selectable continueButton;
        public Selectable optionsButton;

        [Flags]
        public enum OptionalButtons
        {
            None,
            Continue,
            Options,
        }

        public OptionalButtons enabledButtons = OptionalButtons.None;

        public void DebugDisable()
        {
            continueButton.interactable = false;
            optionsButton.interactable = false;
        }

        public void OnContinuePress()
        {
            print("i am bender please insert girder");
        }

        public void OnNewGamePress()
        {
            GameManager.ChangeToScene("SolarSystem");
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