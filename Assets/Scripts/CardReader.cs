using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    private Transform m_KeycardTransform;
    private Vector3 m_HoverEntry;
    private bool m_SwipeIsValid = false;
    public float AllowedUprightErrorRange;
    public GameObject VisualLockToHide;
    public ChangeMaterial GreenLight;
    public ChangeMaterial RedLight;
    public DoorHandle doorHandleScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_KeycardTransform != null) {
            Vector3 keycardUp = m_KeycardTransform.forward;
            float dot = Vector3.Dot(keycardUp, Vector3.up);

            if (dot < 1 - AllowedUprightErrorRange) {
                m_SwipeIsValid = false;
			}
		}
    }

	public override bool CanSelect(IXRSelectInteractable interactable) {
        return false;
	}

	protected override void OnHoverEntered(HoverEnterEventArgs args) {
		base.OnHoverEntered(args);
        m_KeycardTransform = args.interactableObject.transform;
        m_HoverEntry = m_KeycardTransform.position;
        m_SwipeIsValid = true;

    }
	protected override void OnHoverExited(HoverExitEventArgs args) {
		base.OnHoverExited(args);

        Vector3 entryToExit = m_KeycardTransform.position - m_HoverEntry;

        if (m_SwipeIsValid && entryToExit.y < -0.15f) {
            VisualLockToHide.gameObject.SetActive(false);
            StartCoroutine(flashLight(true));
            doorHandleScript.SetMovable(true);
        } else {
            StartCoroutine(flashLight(false));
        }

        m_KeycardTransform = null;
	}

    IEnumerator flashLight(bool isGreen) {
        if (isGreen) {
            GreenLight.SetOtherMaterial();
            yield return new WaitForSeconds(1);
            GreenLight.SetOriginalMaterial();
        } else {
            RedLight.SetOtherMaterial();
            yield return new WaitForSeconds(1);
            RedLight.SetOriginalMaterial();
        }
	}
}
