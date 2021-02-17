using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.UI
{

    public class SidePanelController : MonoBehaviour
    {
        public GameObject sidePanel;

        // Start is called before the first frame update
        void Start()
        {
            sidePanel.SetActive(false);
        }

        void SelectObject(GameObject o)
        {
            if (o.tag != GameManager.SELECT_TAG_NAME)
            {
                Debug.LogWarning("Trying to select an object that isn't tagged as being selectable!");
            }

            sidePanel.SetActive(true);
        }

        void ClearSelection()
        {
            sidePanel.SetActive(false);
        }

    }

}
