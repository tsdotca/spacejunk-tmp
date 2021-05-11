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
        public GameObject optionsDialog;

        public Button continueButton;
        public Button newGameButton;
        public Button loadGameButton;
        public Button optionsButton;
        public Button quitButton;

        [Flags]
        public enum OptionalButtons
        {
            None,
            Continue,
            LoadGame,
        }

        public OptionalButtons enabledButtons = OptionalButtons.None;

        void Start()
        {
            GameManager.CreateFirstInstance();
            GameManager.GetInstance().LoadDefaults();

            // TODO once we get save games
            continueButton.interactable = false;
            loadGameButton.interactable = false;

            continueButton.onClick.AddListener(OnContinue);
            newGameButton.onClick.AddListener(OnNewGame);
            loadGameButton.onClick.AddListener(OnLoadGame);
            optionsButton.onClick.AddListener(OnOptions);
            quitButton.onClick.AddListener(OnQuit);
        }

        #region Main menu handlers

        public void OnContinue()
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
            print("options");
        }

        public void OnQuit()
        {
            print("goodbye");
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("SolarSystem");
        }

        #endregion
    }

}