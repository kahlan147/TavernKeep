using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    public GameObject CameraRig;
    [SerializeField]
    private float speed;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    // Update is called once per frame
    void Update()
    {
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
            Vector3 newPosition = CameraRig.transform.position + Camera.main.transform.forward * touchpad.y * speed * Time.deltaTime;
            CameraRig.transform.position = new Vector3(newPosition.x, 0, newPosition.z);
            newPosition = CameraRig.transform.position + Camera.main.transform.right * touchpad.x * speed * Time.deltaTime;
            CameraRig.transform.position = new Vector3(newPosition.x, 0, newPosition.z);
        }
    }
}
