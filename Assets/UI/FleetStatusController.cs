using UnityEngine;
using UnityEngine.UI;

namespace SpaceJunk.UI
{
    public class FleetStatusController : MonoBehaviour
    {
        // eventually will be able to do flagship image

        public Text flagshipNameText;

        public GameObject auxFleetScrollView;  // TODO better type also wtf

        #region infopanel

        public GameObject infoPanel;

        public Button selectCrewButton;
        public Button selectPowerButton;
        public Button selectCargoButton;

        public Text tempStatusText;

        #endregion

        void Start()
        {
            selectCrewButton.onClick.AddListener(OnCrewButton);
            selectPowerButton.onClick.AddListener(OnPowerButton);
            selectCargoButton.onClick.AddListener(OnCargoButton);
        }

        protected void OnCrewButton()
        {
            tempStatusText.text = "lskdjf crew";
        }

        protected void OnPowerButton()
        {
            tempStatusText.text = "aaaaaaaaaaa power";
        }

        protected void OnCargoButton()
        {
            tempStatusText.text = "caaaaaaaaargo";
        }
    }
}