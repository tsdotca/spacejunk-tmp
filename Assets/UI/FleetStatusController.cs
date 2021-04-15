using UnityEngine;
using UnityEngine.UI;

namespace SpaceJunk.UI
{
    public class FleetStatusController : DialogControllerBase
    {
        protected override void InitUI()
        {
            this.alternateButton.gameObject.SetActive(false);
            this.cancelButton.gameObject.SetActive(false);
        }

        protected override void OnAffirmativeAction()
        {
            this.Close();
        }
    }

}