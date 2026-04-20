using UnityEngine;
using UnityEngine.SceneManagement;

public class NextManager : MonoBehaviour
{


    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");

    }


    public void goToTwo()
    {
        SceneManager.LoadScene("level 2");

    }


    public void goToThree()
    {
        SceneManager.LoadScene("level 3");

    }


}

