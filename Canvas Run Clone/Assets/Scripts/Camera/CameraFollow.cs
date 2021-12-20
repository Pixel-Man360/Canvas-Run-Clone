using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    

    void OnEnable()
    {
        SpawnHandler.OnBallsInstantiatedAtStart += MakeCameraFollowBalls;
    }

    void OnDisable() 
    {
        SpawnHandler.OnBallsInstantiatedAtStart -= MakeCameraFollowBalls;
    }

    void MakeCameraFollowBalls(Dictionary<int, GameObject> spawnerList)
    {
        if(spawnerList.TryGetValue(0, out GameObject obj))
        {
            _camera.Follow = obj.transform;
        }

        else 
        {
            for(int i = 1 ; i < spawnerList.Count; i++)
            {
                if(spawnerList.TryGetValue(i, out obj))
                {
                    _camera.Follow = obj.transform;
                    break;
                }
            }
        }
    }
    
}
