using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vec3 = UnityEngine.Vector3;	//FIXME: This should be in a global game namespace instead

public class ShipController : MonoBehaviour
{
    [Header("Handling Properties")]
    public float enginePower = 5000;
    public float turnRate = 1800;
    public float strafeFactor = 0.5f;

    public bool isThrusting { get; private set; }
    public Transform[] thrustPoints;

    // Fixes the Intertia Tensor so that child physics objects don't affect ship handling.
    public bool fixedInertia = true;

    [Header("Grapple Properties")]
    public Transform grappleProjectile;
    public Transform attachmentPoint;
    public Transform launchPoint;
    public float grappleRange = 15f;
    public float grappleSpeed = 10f;
    public float grappleTowDesiredDistance = 3f;
    public float grappleSpringStrength = 30f;   // 10 is unity default Spring power for SpringJoint


    // Private stuff
    private Vector3 vel;
    private float rotation;
    private Rigidbody body;

    private Transform activeProjectile;
    private bool grappleInFlight = false;

    private GameObject attachedDraggable;
    private bool isDragging = false;

    private ConfigurableJoint joint;

    private LineRenderer line;



    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        vel.Set(0, 0, 0);
        rotation = 0;

        isThrusting = false;

        body.inertiaTensor = fixedInertia ? new vec3(1, 1, 1) : body.inertiaTensor;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        vel.y = 0;

        vel.z = Input.GetAxisRaw("Thrust");
        vel.x = Input.GetAxisRaw("Strafe");
        rotation = Input.GetAxisRaw("Rotate");

        vel.Normalize();

        if (vel.z > 0) isThrusting = true;
        else isThrusting = false;


        // FIXME: This is an ugly hack, please kill it with fire
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown("f") && !grappleInFlight)
        {
            grappleInFlight = true;
            line.enabled = true;

            activeProjectile = Instantiate(grappleProjectile, launchPoint.position, launchPoint.rotation);
            activeProjectile.GetComponent<GrappleHook>().AttachPlayer(this);
            Rigidbody rb = activeProjectile.GetComponent<Rigidbody>();
            rb.velocity = GetComponent<Rigidbody>().velocity;
            Vector3 grappleVel = Vector3.forward * grappleSpeed;

            rb.AddRelativeForce(grappleVel, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown("g") && isDragging)
        {
            DisconnectDraggable();
        }

        if (grappleInFlight && activeProjectile != null)
        {
            float dist = Vector3.Distance(activeProjectile.position, launchPoint.position);
            if (dist >= grappleRange)
            {
                DestroyGrapple();
            }
            else
            {
                Vector3[] segments = new Vector3[] { attachmentPoint.position, activeProjectile.transform.position };
                line.SetPositions(segments);
            }
        }


        if (isDragging)
        {
            Vector3[] segments = new Vector3[] { attachmentPoint.position, attachedDraggable.transform.position };
            line.SetPositions(segments);
        }
    }

    void DestroyGrapple()
    {
        GameObject.Destroy(activeProjectile.gameObject);
        grappleInFlight = false;
        if (!isDragging) line.enabled = false;
    }


    public void HitDraggable(GameObject dragObject)
    {
        DestroyGrapple();

        if (!isDragging)
        {
            ConnectDraggable(dragObject);
        }
        else // We're already dragging something
        {
            DisconnectDraggable();
            ConnectDraggable(dragObject);
        }
    }



    void DisconnectDraggable()
    {
        if (attachedDraggable)
        {
            joint.connectedBody = null;
            isDragging = false;
            attachedDraggable = null;

            Destroy(this.GetComponent<ConfigurableJoint>());
        }

        line.enabled = false;
    }



    bool ConnectDraggable(GameObject dragObject)
    {
        bool success = false;
        Transform other = dragObject.GetComponent<Draggable>().GetDraggable();

        if (other)
        {
            InitializeJoint(other.GetComponent<Rigidbody>());
            attachedDraggable = other.gameObject;
            isDragging = true;
            success = true;
        }

        return success;
    }


    void InitializeJoint(Rigidbody rb)
    {
        joint = gameObject.AddComponent<ConfigurableJoint>();
        line.enabled = true;

        joint.connectedBody = rb;
        joint.autoConfigureConnectedAnchor = false;
        joint.enableCollision = true;
        joint.anchor = vec3.zero;
        joint.axis = vec3.zero;
        joint.connectedAnchor = vec3.forward * grappleTowDesiredDistance;
        joint.secondaryAxis = vec3.zero;
        joint.xMotion = ConfigurableJointMotion.Limited;
        joint.yMotion = ConfigurableJointMotion.Locked;
        joint.zMotion = ConfigurableJointMotion.Limited;

        SoftJointLimit linLim = joint.linearLimit;
        linLim.limit = grappleTowDesiredDistance;
        linLim.bounciness = 1f;
        joint.linearLimit = linLim;

        SoftJointLimitSpring limSpring = joint.linearLimitSpring;
        limSpring.spring = grappleSpringStrength;
        limSpring.damper = 5;
        joint.linearLimitSpring = limSpring;

        joint.enableCollision = true;
    }

    void FixedUpdate()
    {
        float force = enginePower * Time.deltaTime; // vel * enginePower * Time.deltaTime;
        float torque = rotation * turnRate * Time.deltaTime;
        /*
		body.AddRelativeForce(force);
		body.AddRelativeTorque(0, torque, 0);
		*/

        foreach (Transform tp in thrustPoints)
        {
            body.AddForceAtPosition((body.transform.forward * vel.z * force) / thrustPoints.Length, tp.position);
        }

        body.AddRelativeForce(vel.x * force * strafeFactor, 0, 0);
        body.AddRelativeTorque(0, torque, 0);
    }
}