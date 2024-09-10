using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private Transform anchorPoint;
    [SerializeField] private LineRenderer rope;

    private DistanceJoint2D joint;

    // Expose the IsGrappling property
    public bool IsGrappling { get; private set; }

    // Expose the anchor position
    public Vector2 AnchorPosition
    {
        get
        {
            if (anchorPoint != null)
            {
                return anchorPoint.position;
            }
            else
            {
                return transform.position;
            }
        }
    }

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;
        IsGrappling = false;
    }

    void Update()
    {
        if (joint.enabled)
        {
            rope.SetPosition(0, transform.position);
            rope.SetPosition(1, joint.connectedAnchor);

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 currentVelocity = rb.velocity;
            float maxSwingVelocity = 10f; // You can set this
            rb.velocity = new Vector2(
                Mathf.Clamp(currentVelocity.x, -maxSwingVelocity, maxSwingVelocity),
                Mathf.Clamp(currentVelocity.y, -maxSwingVelocity, maxSwingVelocity)
            );
        }
    }

    public void ToggleGrapplingHook()
    {
        if (!joint.enabled)
        {
            if (anchorPoint != null)
            {
                joint.connectedAnchor = anchorPoint.position;
                joint.enabled = true;
                joint.distance = grappleLength;

                rope.positionCount = 2;
                rope.SetPosition(0, transform.position);
                rope.SetPosition(1, anchorPoint.position);
                rope.enabled = true;
                IsGrappling = true;
            }
        }
        else
        {
            joint.enabled = false;
            rope.enabled = false;
            IsGrappling = false;
        }
    }
}












