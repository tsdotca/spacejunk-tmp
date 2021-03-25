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
        public GameObject newGameDialog;

        public Selectable continueButton;
        public Selectable loadGameButton;

        [Flags]
        public enum OptionalButtons
        {
            None,
            Continue,
            LoadGame,
        }

        public OptionalButtons enabledButtons = OptionalButtons.None;

        public void Start()
        {
            DebugDisable();  // TODO once we get save games and stuff
        }

        public void DebugDisable()
        {
            continueButton.interactable = false;
            loadGameButton.interactable = false;
        }

        #region Main menu handlers

        public void OnContinueGame()
        {
            print("i am bender please insert girder");
        }

        public void OnNewGame()
        {
            print("new game");
            newGameDialog.SetActive(true);
        }

        public void OnLoadGame()
        {
            print("now you want to LOAD a GAME?");
        }

        public void OnOptions()
        {
        }

        public void OnQuitGame()
        {
            Debug.Log("goodbye");
            Application.Quit();
        }

        #endregion

        #region New game dialog handlers

        public void OnNewGameBack()
        {
            newGameDialog.SetActive(false);
        }

        public void OnStartGame()
        {
            GameManager.GetInstance().ChangeToScene("SolarSystem");
        }

        #endregion
    }

}