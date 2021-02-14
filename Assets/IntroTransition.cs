using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LogoFadeout());
    }

    IEnumerator LogoFadeout()
    {
        yield return new WaitForSeconds(1);

        // scene transition
        SceneManager.LoadScene("MainMenu");
    }
}
