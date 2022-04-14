using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject rocket;
    public int _startLevelAsteriodsNum;
    private bool _allAsteriodsOffScreen;
    private int levelAsteroidNum;
    private Camera mainCam;
    private int asteriodLife;

    private void Start()
    {
        levelAsteroidNum.SetActive(false);
        mainCam = Camera.main;
        _startLevelAsteroidsNum = 2;
        CreateAsteroids(-startLevelAsteroidsNum);
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.8f);

        if (asteroidLife <= 0)
        {
            asteroidLife = 6;
            CreateAsteroids(1);
        }

        float sceneWidth = mainCam.orthographicSize * 2 * mainCam.aspect;
        float sceneHeight = mainCam.orthographicSize * 2;
        float sceneRightEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        _allAsteroidsOffScreen = true;

    }

    private void CreateAsteroids(float asteroidsNum)
    {
        for (int i = 1; i <= asteroidsNum; i++)
        {
            GameObject AsteroidClone = Instantiate(asteroidsNum, new Vector2(Random.Range(-10, 10), 6f), transform.rotation);
            AsteroidClone.GetComponent().SetGeneration(1);
            AsteroidClone.SetActive(true);
        }
    }

    public void RocketFail()
    {
        Cursor.visible = true;
        print("GAME OVER");
    }

    public void asteroidDestroyed()
    {
        asteroidLife--;
    }

    public int startLevelAsteroidsNum
    {
        get { return _startLevelAsteroidsNum; }
    }

    public bool allAsteroidsOffScreen
    {
        get { return _allAsteroidsOffScreen; }
    }

}
