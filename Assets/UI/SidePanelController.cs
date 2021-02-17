using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.UI
{

    public class SidePanelController : MonoBehaviour
    {
        #region UI components
        // Computed reference to various UI components
        // TODO: possible template for this kind of shit?
        protected GameObject clockText;
        protected GameObject descriptionLabelText;
        protected GameObject cancelAction;
        protected GameObject affirmativeAction;

        protected GameObject _sidePanel;
        public GameObject sidePanel
        {
            get { return _sidePanel; }

            protected set
            {
                this.clockText = GetChildWithName(value, "Clock");  // TODO a special object, not just text label
                this.descriptionLabelText = GetChildWithName(value, "SelectedDescriptionText");
                this.cancelAction = GetChildWithName(value, "CancelAction");
                this.affirmativeAction = GetChildWithName(value, "AffirmativeAction");
            }
        }
        #endregion

        // TODO: refactor into a utility method and/or determine better strategy
        public static GameObject GetChildWithName(GameObject obj, string name)
        {
            Transform trans = obj.transform;
            Transform childTrans = trans.Find(name);
            if (childTrans != null)
            {
                return childTrans.gameObject;
            }
            else
            {
                return null;
            }
        }

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
