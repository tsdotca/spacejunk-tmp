using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTransition : MonoBehaviour
{
    public float introDelaySeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: if global options set to skip intro then Transitio()
        StartCoroutine(LogoFadeout());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Transition();
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
