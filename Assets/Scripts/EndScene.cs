using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void returnToMenu() {
        SceneManager.LoadScene(0);
    }
}
