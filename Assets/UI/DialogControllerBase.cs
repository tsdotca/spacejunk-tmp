using UnityEngine;
using UnityEngine.UI;

namespace SpaceJunk.UI
{
    public class DialogControllerBase : MonoBehaviour
    {
        protected Button alternateButton;
        protected Button cancelButton;
        protected Button affirmButton;

        // Start is called before the first frame update
        void Start()
        {
            // TODO maybe set of flags depending on dialog?
            alternateButton = FindButton("AlternateAction");
            alternateButton.onClick.AddListener(() => OnAlternateAction());
            cancelButton = FindButton("CancelAction");
            cancelButton.onClick.AddListener(() => OnCancelAction());
            affirmButton = FindButton("AffirmativeAction");
            affirmButton.onClick.AddListener(() => OnAffirmativeAction());

            InitUI();
        }

        protected virtual void InitUI()
        {

        }

        protected Button FindButton(string name)
        {
            return this.gameObject.transform.Find(name).GetComponent<Button>();
        }

        protected virtual void OnAlternateAction()
        {
            Debug.LogError("alternate needs to be overriden in subclass");
        }

        protected virtual void OnCancelAction()
        {
            Debug.LogError("cancel needs to be overriden in subclass");
        }

        protected virtual void OnAffirmativeAction()
        {
            Debug.LogError("affirm needs to be overriden in subclass");
        }

        public void Close()
        {
            this.gameObject.SetActive(false);
        }
    }
}