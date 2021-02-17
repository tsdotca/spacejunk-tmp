using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// whole bunch of refactoring needs to be done:
///     1. possible an IClickable thing?
///     2. define an interface for a responder
///         currently just ClearSelection() and SelectObject()
/// </summary>
public class SelectionController : MonoBehaviour
{
    public GameObject currentSelected = null;
    public GameObject targetWidget = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
