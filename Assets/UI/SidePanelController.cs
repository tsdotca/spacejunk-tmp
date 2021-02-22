using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.UI
{
    public class SidePanelController : MonoBehaviour
    {
        public GameObject sidePanel;

        #region UI components
        protected GameObject clockText;

        protected GameObject contextInfoPanel;
        //protected GameObject descriptionLabelText;

        protected GameObject mainActionButtonsPanel;
        protected GameObject cancelAction;
        protected GameObject affirmativeAction;

        public void RefreshSidePanel()
        {
            this.clockText = GetChildWithName(sidePanel, "Clock");

            this.contextInfoPanel = GetChildWithName(sidePanel, "ContextInfoPanel");
            this.contextInfoPanel.SetActive(false);
            //this.descriptionLabelText = GetChildWithName(this.contextInfoPanel, "SelectedDescriptionText");

            this.mainActionButtonsPanel = GetChildWithName(sidePanel, "MainActionButtonsPanel");
            this.cancelAction = GetChildWithName(this.mainActionButtonsPanel, "CancelAction");
            this.affirmativeAction = GetChildWithName(this.mainActionButtonsPanel, "AffirmativeAction");
            this.mainActionButtonsPanel.SetActive(false);
        }
        #endregion

        public void SetSidePanel(GameObject sidePanel)
        {
            this.sidePanel = sidePanel;
            RefreshSidePanel();
        }

        void SelectObject(GameObject o)
        {
            if (o.tag != GameManager.SELECT_TAG_NAME)
            {
                Debug.LogWarning("Trying to select an object that isn't tagged as being selectable!");
            }

            contextInfoPanel.SetActive(true);
        }

        void ClearSelection()
        {
            contextInfoPanel.SetActive(false);
        }

        /// <summary>
        /// Like Transform.Find(), but does DFS on all children.
        /// </summary>
        public static GameObject GetChildWithName(GameObject obj, string name)
        {
            Transform trans = obj.transform;
            var childTrans = trans.Find(name);
            if (childTrans)
                return childTrans.gameObject;
            foreach (Transform child in trans)
            {
                childTrans = trans.Find(name);
                if (childTrans)
                    return childTrans.gameObject;
                else if (GetChildWithName(child.gameObject, name) is var result && result)
                    return result;
                else
                    continue;
            }
            return null;
        }
    }
}
