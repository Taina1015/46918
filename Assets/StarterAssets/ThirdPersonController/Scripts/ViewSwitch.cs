using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ViewSwitch : MonoBehaviour
{
    public InputActionReference action_view;
    private float scrolling_value;
    public GameObject FollowCamera;

    private CinemachineVirtualCamera cam_CV;
    private Cinemachine3rdPersonFollow cam_3rd;
    private float distance_1st = -0.2f;
    private float distance_3rd =4f;
    private float distance_step = 0.2f;
    private float FOV_3rd = 40f;
    private float FOV_1st = 50f;
    private Vector3 shouldOffset_1st = new Vector3(0f, 0.32f, 0f);
    private Vector3 shouldOffset_3rd = new Vector3(0f, 0f, 0f);
    private Vector3 damping_1st = new Vector3(0f, 0f, 0f);
    private Vector3 damping_3rd = new Vector3(0.1f, 0.25f, 0.3f);

    private void Awake(){
        action_view.action.performed += _x => scrolling_value = _x.action.ReadValue<float>();
    }
    void Start()
    {
        cam_CV = FollowCamera.GetComponent<CinemachineVirtualCamera>();
        cam_3rd = cam_CV.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        cam_3rd.CameraDistance = 4f;
        float fraction = (cam_3rd.CameraDistance - distance_1st) / (distance_3rd - distance_1st);
        cam_CV.m_Lens.FieldOfView = Mathf.Lerp(FOV_1st, FOV_3rd, fraction);
        cam_3rd.ShoulderOffset = Vector3.Lerp(shouldOffset_1st, shouldOffset_3rd, fraction);
        cam_3rd.Damping = Vector3.Lerp(damping_1st, damping_3rd, fraction);

    }

    void Update()
    {
       CameraZoom() ;

    }

    private void CameraZoom(){
        if(scrolling_value != 0){
            if(scrolling_value > 0){
                Debug.Log("Scroll Up");
            if (cam_3rd.CameraDistance > distance_1st){
                cam_3rd.CameraDistance = cam_3rd.CameraDistance - distance_step;
            }
            else{
                cam_3rd.CameraDistance = distance_1st;
            }
            }
             if(scrolling_value < 0){
            Debug.Log("Scroll Down");
            if(cam_3rd.CameraDistance < distance_3rd){
                cam_3rd.CameraDistance = cam_3rd.CameraDistance + distance_step;
            }
            else{
                cam_3rd.CameraDistance = distance_3rd;
            }
            }
        float fraction = (cam_3rd.CameraDistance - distance_1st) / (distance_3rd - distance_1st);
        cam_CV.m_Lens.FieldOfView = Mathf.Lerp(FOV_1st, FOV_3rd, fraction);
        cam_3rd.ShoulderOffset = Vector3.Lerp(shouldOffset_1st, shouldOffset_3rd, fraction);
        cam_3rd.Damping = Vector3.Lerp(damping_1st, damping_3rd, fraction);
            
        }
       
    }
}
