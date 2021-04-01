using UnityEngine;
using UnityEngine.UI;

using SpaceJunk.Core;

namespace SpaceJunk.UI
{
    // TODO: configure this stuff based on config values, UX/accessibility, etc.
    public class StatusTextPalette
    {
        public Color Default = new Color(0.0f, 1.0f, 0.0f);
        public Color Warning = new Color(0.5f, 0.5f, 0.0f);
        public Color Critical = new Color(1.0f, 0.0f, 0.0f);
    }

    public class TopMenubarController : MonoBehaviour
    {
        protected StatusTextPalette currentPalette;

        public Button mainMenuButton;
        public Button fleetStatusButton;
        public Button pendingTasksButton;

        // icons ignored, set in editor

        public Text powerLabel;
        public Text computeCapLabel;
        public Text cargoLabel;

        public GameObject fleetStatusDialog;
        public GameObject pendingTasksDialog;

        void Start()
        {
            currentPalette = new StatusTextPalette();
        }

        public void OnMainMenu()
        {
            Debug.Log("main menu");
        }

        public void OnFleetStatus()
        {
            fleetStatusDialog.SetActive(true);
        }

        public void OnPendingTasks()
        {
            pendingTasksDialog.SetActive(true);
        }

        /// <summary>
        /// Called every so often to make sure the top menubar stats are updated.
        /// </summary>
        public void UpdateGameStatus(GameState state)
        {
            // TODO: use a separate function/class to scale each colour
            //       based on the resource type and value
            //       (note that requires refactoring resources)
            powerLabel.text = state.power.ToString();
            powerLabel.color = currentPalette.Default;
            computeCapLabel.text = state.computation.ToString();
            computeCapLabel.color = currentPalette.Default;
            cargoLabel.text = state.cargoCount.ToString();
            cargoLabel.color = currentPalette.Default;
        }
    }

}