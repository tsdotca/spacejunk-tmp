using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceJunk.UI
{


    public class WindowManager : MonoBehaviour
    {
        protected static void Pop()
        {

        }

        protected static void Push(GameObject dialog)
        {
            dialog.SetActive(true);
        }

        /// <summary>
        /// Raise an existing dialog (usually configured in the Unity Editor).
        /// 
        /// When the dialog is popped, it is preserved afterwards.
        /// </summary>
        /// <param name="existingDialog"></param>
        public static void/*?*/ RaiseDialog(GameObject existingDialog)
        {
            Push(existingDialog);
        }

        /// <summary>
        ///  Create a new dialog by name. Once the dialog is popped, it is destroyed.
        /// </summary>
        /// <param name="name"></param>
        public static void/*?*/ SpawnNewDialog(string name /* , GameObject controller  ??? */)
        {

        }

        public void OnEscape()
        {
            print("Escape");
        }

        public void OnScrollWheel()
        {
            print("OnScrollWheel");
        }
    }
}
