using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject cam1 = null;
    [SerializeField] private GameObject cam2 = null;
    [SerializeField] private GameObject dirLight = null;
    [SerializeField] private GameObject postProssessing;
    private void Start()
    {
        dirLight.SetActive(false);
        postProssessing.SetActive(false);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { 
            cam1.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 40f;
            cam1.SetActive(true);
            cam2.SetActive(false);
            dirLight.SetActive(false);
            postProssessing.SetActive(false);
        }
         if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            dirLight.SetActive(true);
            postProssessing.SetActive(true);
        }
    }
}
