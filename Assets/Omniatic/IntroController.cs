using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Omniatic
{
    // this code is garbage and should probably be refactored into something better
    public class IntroController : MonoBehaviour
    {
        public GameObject buddyObject;
        public GameObject logoObject;

        protected readonly float fadeInRate = 0.5f;
        protected readonly float fadeOutRate = 0.8f;
        protected readonly float blinkDelay = 0.3f;

        protected SpriteRenderer buddySprite;

        public Sprite lookLeft;
        public Sprite lookRight;
        public Sprite lookCentre;
        public Sprite blink;

        void Start()
        {
            buddySprite = buddyObject.GetComponent<SpriteRenderer>();

            // TODO: if global options set to skip intro then Transition()

            StartCoroutine(AnimationGo());
        }

        IEnumerator AnimationGo()
        {
            yield return new WaitForSeconds(fadeInRate);

            Blink();
            yield return new WaitForSeconds(blinkDelay);
            LookLeft();
            yield return new WaitForSeconds(blinkDelay);

            Blink();
            yield return new WaitForSeconds(blinkDelay);
            LookRight();
            yield return new WaitForSeconds(blinkDelay);

            Blink();
            yield return new WaitForSeconds(blinkDelay);
            LookLeft();
            yield return new WaitForSeconds(blinkDelay);

            Blink();
            yield return new WaitForSeconds(blinkDelay);
            LookCentre();
            yield return new WaitForSeconds(blinkDelay * 4);

            LookRight();
            yield return new WaitForSeconds(blinkDelay);

            StartCoroutine(Fadeout());
        }

        IEnumerator Fadeout()
        {
            yield return new WaitForSeconds(fadeOutRate);

            Transition();
        }

        /// <summary>
        /// Event handler for when the user wants to skip the intro.
        /// </summary>
        public void OnForcedTransition(InputAction.CallbackContext context)
        {
            Transition();
        }

        protected void Transition()
        {
            SceneManager.LoadScene("MainMenu");
        }

        #region buddy animations

        void Blink()
        {
            buddySprite.sprite = blink;
        }

        void LookCentre()
        {
            buddySprite.sprite = lookCentre;
        }

        void LookLeft()
        {
            buddySprite.sprite = lookLeft;
        }

        void LookRight()
        {
            buddySprite.sprite = lookRight;
        }

        #endregion buddy
    }

}