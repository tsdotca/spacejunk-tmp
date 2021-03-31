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

        public GameObject mainMenuButton;
        public GameObject fleetStatusButton;
        public GameObject pendingTasksButton;

        // icons ignored, set in editor

        public GameObject powerLabel;
        public GameObject computeCapLabel;
        public GameObject cargoLabel;

        private void UpdateLabelText(GameObject label, string newText)
        {
            var text = label.GetComponent<Text>();
            text.text = newText;
            text.color = currentPalette.Default;
        }

        void Start()
        {
            currentPalette = new StatusTextPalette();
            UpdateLabelText(powerLabel, "asdf");
            UpdateLabelText(computeCapLabel, "haha cpu");
            UpdateLabelText(cargoLabel, "0/100");
        }

        public void OnMainMenu()
        {
            Debug.Log("main menu");
        }

        public void OnFleetStatus()
        {
            Debug.Log("fleet status");
        }

        public void OnPendingTasks()
        {
            Debug.Log("on pending tasks");
        }

        /// <summary>
        /// Called every so often to make sure the top menubar stats are updated.
        /// </summary>
        public void UpdateGameStatus(GameState state)
        {
            // TODO
        }
    }

}