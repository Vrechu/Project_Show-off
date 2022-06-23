using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerMarker : MonoBehaviour
{
    [SerializeField] GameObject[] icons = new GameObject[4];
    private Transform cameraTransform;
    [SerializeField] private bool OnPlayer = false;
    [SerializeField] private int playerNumber = 0;

    private void Awake()
    {
        PlacePlayers.OnPlayerSpawn += SetCamera;
    }
    private void OnDestroy()
    {
        PlacePlayers.OnPlayerSpawn -= SetCamera;
    }

    private void Start()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(false);
        }
        if (OnPlayer)
        {
            icons[GetComponentInParent<PlayerProfileAccess>().PlayerProfile.PlayerNumber].SetActive(true);
            SetCamera();
        }
        else icons[playerNumber].SetActive(true);
    }

    public void SetCamera()
    {
        cameraTransform = LevelSettings.Instance.CameraManager.MyCamera(0).transform;
        transform.rotation = cameraTransform.rotation;
    }
}
