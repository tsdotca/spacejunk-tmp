using UnityEngine;
using UnityEngine.UI;

using SpaceJunk.Core;

namespace SpaceJunk.UI
{
    public class InfoPanelController : MonoBehaviour
    {
        public GameObject infoPanel;
        public Text planetDescriptionText;

        void Start()
        {
            infoPanel.SetActive(false);
        }

        public void Select(Satellite planet)
        {
            planetDescriptionText.text = planet.description;
            infoPanel.SetActive(true);
        }

        public void Disable()
        {
            infoPanel.SetActive(false);
        }
    }
}