using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laserPointer : MonoBehaviour
{

    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    OvrAvatar ovrAvatar;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);
        //cameraRig = FindObjectOfType<OVRCameraRig>();
        ovrAvatar = FindObjectOfType<OvrAvatar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawTouch.RIndexTrigger))
        {
            ShootLaserFromTargetPosition(/*cameraRig.rightHandAnchor.localPosition*/
  ovrAvatar.HandRight.transform.position, ovrAvatar.HandRight.transform.forward, laserMaxLength);

            laserLineRenderer.enabled = true;
        }
        else
        {
       
            laserLineRenderer.enabled = false;
        }
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        Vector3 endPosition = targetPosition + (length * direction);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, length))
        {
            endPosition = raycastHit.point;
        }
        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
