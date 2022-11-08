using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destination = "Earth";
    public static Action<GameEnvironment> OnGameEnvironmentChange;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (destination)
            {
                case "Moon":
                    OnGameEnvironmentChange?.Invoke(GameEnvironment.Moon);
                    break;
                case "Earth":
                    OnGameEnvironmentChange?.Invoke(GameEnvironment.Earth);
                    break;
                default:
                    OnGameEnvironmentChange?.Invoke(GameEnvironment.Default);
                    break;
            }
            SceneManager.LoadScene(destination);
        }
    }
}
