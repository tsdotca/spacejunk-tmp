using UnityEngine;

using SpaceJunk.Core;

namespace SpaceJunk.UI
{
    // FIXME: This class assumes that it is attached to the same UI canvas instance.
    public class SidePanelController : MonoBehaviour
    {
        protected GameObject _sidebarPanel;

        protected GameObject clockText;

        protected GameObject contextInfoPanel;
        //protected GameObject descriptionLabelText;

        protected GameObject mainActionButtonsPanel;
        protected GameObject cancelAction;
        protected GameObject affirmativeAction;

        public void RefreshSidePanel()
        {
            this._sidebarPanel = this.gameObject;  // FIXME!!!

            this.clockText = GetChildWithName(_sidebarPanel, "Clock");

            this.contextInfoPanel = GetChildWithName(_sidebarPanel, "ContextInfoPanel");
            this.contextInfoPanel.SetActive(false);
            //this.descriptionLabelText = GetChildWithName(this.contextInfoPanel, "SelectedDescriptionText");

            this.mainActionButtonsPanel = GetChildWithName(_sidebarPanel, "MainActionButtonsPanel");
            this.cancelAction = GetChildWithName(this.mainActionButtonsPanel, "CancelAction");
            this.affirmativeAction = GetChildWithName(this.mainActionButtonsPanel, "AffirmativeAction");
            this.mainActionButtonsPanel.SetActive(false);
        }

        void SelectObject(GameObject o)
        {
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
