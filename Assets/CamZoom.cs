using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent (typeof (CinemachineVirtualCamera))]
public class CamZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Light redSpotlight;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            cam.enabled = true;    
            cam.m_Lens.FieldOfView = 78f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            cam.enabled = true;
            cam.m_Lens.FieldOfView = 25f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cam.enabled = true;
            cam.m_Lens.FieldOfView = 15f;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            redSpotlight.enabled = !redSpotlight.enabled;
        }
    }
}
