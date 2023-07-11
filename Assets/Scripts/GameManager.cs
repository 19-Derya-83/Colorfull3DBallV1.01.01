using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {

            RestartButton();

        }

    }

    public void RestartButton()

    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
