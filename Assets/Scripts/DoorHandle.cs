using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{

    public Transform DraggedTransform;
    public Vector3 LocalDragDirection;
    public float DragDistance;
    public int DoorWeight = 20;
    private bool isMovable = false;

    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private Vector3 m_WorldDragDirection;

    // Start is called before the first frame update
    void Start()
    {
        m_WorldDragDirection = transform.TransformDirection(LocalDragDirection).normalized;
        m_StartPosition = DraggedTransform.position;
        m_EndPosition = m_StartPosition + m_WorldDragDirection * DragDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase) {
		if (isMovable && isSelected) {
            var interactorTransform = firstInteractorSelecting.GetAttachTransform(this);
            Vector3 selfToInteractor = interactorTransform.position - transform.position;
            float dotProduct = Vector3.Dot(selfToInteractor, m_WorldDragDirection);
            float speed = Math.Abs(dotProduct * Time.deltaTime) / DoorWeight;
            if (dotProduct > 0 && Vector3.Dot(DraggedTransform.position - m_EndPosition, m_WorldDragDirection) < 0) {
                DraggedTransform.position = Vector3.MoveTowards(DraggedTransform.position, m_EndPosition, speed);
			} else if (dotProduct < 0 && Vector3.Dot(DraggedTransform.position - m_StartPosition, m_WorldDragDirection) > 0) {
                DraggedTransform.position = Vector3.MoveTowards(DraggedTransform.position, m_StartPosition, speed);
            }
		}
	}

    public void SetMovable(bool MovableSetting) {
        isMovable = MovableSetting;
    }
}
