using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Text EnvironmentName;
    [SerializeField] public Text GravityScale;

    private static float playerGravityState = 9.807f;

    private void Start()
    {
        EnvironmentName.text = $"Environment name: {SceneManager.GetActiveScene().name}";
        GravityScale.text = $"Gravity scale: {playerGravityState}";
    }

    private void OnEnable()
    {
        Portal.OnGameEnvironmentChange += HandleUpdateGameEnvironment;
    }

    private void OnDisable()
    {
        Portal.OnGameEnvironmentChange -= HandleUpdateGameEnvironment;
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

        //EnvironmentName.text = $"Environt Name: {SceneManager.GetActiveScene().name}";
        //GravityScale.text = $"Gravity scale: {playerGravityState}";
    }
}
