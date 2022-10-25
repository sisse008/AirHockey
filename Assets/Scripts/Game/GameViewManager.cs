using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameViewManager : MonoBehaviour
{

    public Transform mobileViewTimeline;
    public Transform pcViewTimeline;

    public CinemachineVirtualCamera pcView;
    public CinemachineVirtualCamera mobileView;


    private void Awake()
    {
        mobileViewTimeline.gameObject.SetActive(false);
        pcViewTimeline.gameObject.SetActive(false);        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Tools.IsMobile())
            SetUpMobileGameView();
        else
            SetupStandaloneGameView();
    }

    void SetUpMobileGameView()
    {
        mobileViewTimeline.gameObject.SetActive(true);
        mobileView.Priority = 1;
        pcView.Priority = 0;
    }

    void SetupStandaloneGameView()
    {
        pcViewTimeline.gameObject.SetActive(true);
        mobileView.Priority = 0;
        pcView.Priority = 1;
    }
}
