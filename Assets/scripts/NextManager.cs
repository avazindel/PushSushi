using UnityEngine;
using UnityEngine.SceneManagement;

public class NextManager : MonoBehaviour
{


    public void goToMenu()
    {
        SceneManager.LoadScene("menu");

    }


    public void howtoplay()
    {
        SceneManager.LoadScene("howto");

    }


    public void goToOne()
    {
        SceneManager.LoadScene("level 1");

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

