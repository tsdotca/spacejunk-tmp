using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.UI
{

    public class SidePanelController : MonoBehaviour
    {
        public GameObject sidePanel;

        #region UI components
        // Computed reference to various UI components
        // TODO: possible template for this kind of shit?
        protected GameObject clockText;
        protected GameObject descriptionLabelText;
        protected GameObject cancelAction;
        protected GameObject affirmativeAction;

        public void RefreshSidePanel()
        {
            this.clockText = GetChildWithName(sidePanel, "Clock");  // TODO a special object, not just text label
            this.descriptionLabelText = GetChildWithName(sidePanel, "SelectedDescriptionText");
            this.cancelAction = GetChildWithName(sidePanel, "CancelAction");
            this.affirmativeAction = GetChildWithName(sidePanel, "AffirmativeAction");
        }
        #endregion

        public void Start()
        {
            RefreshSidePanel();
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

        // TODO: refactor into a utility method and/or determine better strategy
        public static GameObject GetChildWithName(GameObject obj, string name)
        {
            Transform trans = obj.transform;
            Transform childTrans = trans.Find(name);
            return childTrans ? childTrans.gameObject : null;
        }
    }

}
