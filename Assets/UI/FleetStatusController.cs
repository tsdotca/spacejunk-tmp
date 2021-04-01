using UnityEngine;
using UnityEngine.UI;

namespace SpaceJunk.UI
{
    public class FleetStatusController : UIControllerBase
    {
        protected override void OnAffirmativeAction()
        {
            Debug.Log("hooray i know base C# syntax!");
            this.Close();
        }
    }

}