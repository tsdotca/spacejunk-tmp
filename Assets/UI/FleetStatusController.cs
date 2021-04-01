using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceJunk.UI
{
    public class FleetStatusController : MonoBehaviour
    {
        public Button closeDialogButton;

        void Start()
        {
            closeDialogButton.onClick.AddListener(() => this.gameObject.SetActive(false));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}