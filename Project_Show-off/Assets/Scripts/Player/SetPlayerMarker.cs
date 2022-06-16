using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerMarker : MonoBehaviour
{
    [SerializeField] GameObject[] icons = new GameObject[4];
    private Transform cameraTransform;
    [SerializeField] private bool OnPlayer = false;
    [SerializeField] private int playerNumber = 0;

    void Start()
    {
        LevelSettings.OnSettingsReady += SetCamera;
       
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(false);
        }
        if (OnPlayer)
        {
            icons[GetComponentInParent<PlayerProfileAccess>().PlayerProfile.PlayerNumber].SetActive(true);
        }
        else icons[playerNumber].SetActive(true);
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetCamera;
    }

    private void SetCamera()
    {
        cameraTransform = LevelSettings.Instance.CameraManager.MyCamera(0).transform;
        transform.rotation = cameraTransform.rotation;
    }
}
