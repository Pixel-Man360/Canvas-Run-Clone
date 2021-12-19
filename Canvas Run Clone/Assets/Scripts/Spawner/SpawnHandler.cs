using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabList;
    
    private float rightOffset = 0;
    private float leftOffset = 0;
    private Dictionary<int, GameObject> _spawnerList = new Dictionary<int, GameObject>();
    private Dictionary<int, List<GameObject>> _ballsListForEachSpawner = new Dictionary<int, List<GameObject>>();
    
    void Awake()
    {
       AddBallsByWidth(5);
       AddBallsByLength(0, 4, 5);
    }

    
    void AddBallsByWidth(int totalSpawns)
    {
        int xAxis = 0;

        for(int i = 0; i < totalSpawns; i++)
        {
            if(i == 0)
                xAxis = 0;
            
            else if(i % 2 != 0)
                xAxis = 1;
            
            else 
                xAxis = -1;
                
            GameObject spawner = ObjectPool.instance.GetObject(_prefabList[0]);
         
            spawner.SetActive(true);

            if(xAxis == 1)
            {
                spawner.transform.position = new Vector3((rightOffset * xAxis), spawner.transform.position.y, spawner.transform.position.z);
                rightOffset += 1.1f;
            }

            else if(xAxis == -1)
            {
                spawner.transform.position = new Vector3((leftOffset * xAxis), spawner.transform.position.y, spawner.transform.position.z);
                leftOffset += 1.1f;
            }

            else
            {
                spawner.transform.position = new Vector3(0f, spawner.transform.position.y, spawner.transform.position.z);
                leftOffset += 1.1f;
                rightOffset += 1.1f;
            }

            _spawnerList.Add(i, spawner);
        }
    }

        void AddBallsByLength(int startingSpawner, int endingSpawner, int totalBalls)
        {
            for(int i = startingSpawner ; i <= endingSpawner; i++)
            {
                List<GameObject> objList = new List<GameObject>();

                for(int j = 0 ; j < totalBalls; j++)
                {
                    if(_spawnerList.ContainsKey(i))
                    {
                        GameObject ball = ObjectPool.instance.GetObject(_prefabList[1]);
                        ball.SetActive(true);
                        
                        ball.transform.position = _spawnerList[i].transform.position;
                        _spawnerList[i].transform.position = new Vector3(_spawnerList[i].transform.position.x, _spawnerList[i].transform.position.y, _spawnerList[i].transform.position.z - 1.1f);
                        objList.Add(ball);
                        _ballsListForEachSpawner[i] = objList;
                        
                    }
                }
            }
        }
        
    
}
