using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{

    [Header("Color Changing Materials")]
    public Material TouchMaterial;
    public Material DefaultMaterial;
    public int number;
    private Renderer m_rendererToChange;
    private NumberPad NumberPad;
    private bool isTouching = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rendererToChange = gameObject.GetComponent<Renderer>();
        NumberPad = gameObject.GetComponentInParent<NumberPad>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	protected override void OnHoverEntered(HoverEnterEventArgs args) {
        if (!isTouching) {
            isTouching = true;
            base.OnHoverEntered(args);
            m_rendererToChange.material = TouchMaterial;
            NumberPad.ButtonPressed(number);
		}
	}

	protected override void OnHoverExited(HoverExitEventArgs args) {
        if (isTouching) {
            base.OnHoverExited(args);
            m_rendererToChange.material = DefaultMaterial;
            isTouching = false;
		}
    }
}
