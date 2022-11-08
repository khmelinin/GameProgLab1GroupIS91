using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameEnvironment
{
    Earth,
    Moon,
    Default
}

public class GameManager : MonoBehaviour
{
    private static float playerGravityState = 9.807f;

    private void OnEnable()
    {
        Portal.OnGameEnvironmentChange += HandleUpdateGameEnvironment;
    }

    private void OnDisable()
    {
        Portal.OnGameEnvironmentChange -= HandleUpdateGameEnvironment;
    }

    private void Start()
    {

    }

    public void HandleUpdateGameEnvironment(GameEnvironment ge)
    {
        switch (ge)
        {
            case GameEnvironment.Moon:
                playerGravityState = 1.62f;
                break;
            case GameEnvironment.Earth:
                playerGravityState = 9.807f;
                break;
            default:
                playerGravityState = 9.807f;
                break;
        }
        Physics.gravity = new Vector3(0, -playerGravityState, 0);
    }
}
