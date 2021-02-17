using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Omniatic
{


public class IntroController : MonoBehaviour
{
    public float introDelaySeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: if global options set to skip intro then Transitio()
        StartCoroutine(LogoFadeout());
    }

    /// <summary>
    /// Event handler for when the user wants to skip the intro.
    /// </summary>
    public void OnForcedTransition(InputAction.CallbackContext context)
    {

    }

    IEnumerator LogoFadeout()
    {
        yield return new WaitForSeconds(introDelaySeconds);

        Transition();
    }

    protected void Transition()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

}