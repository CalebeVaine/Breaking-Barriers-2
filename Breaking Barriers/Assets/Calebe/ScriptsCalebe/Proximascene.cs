using UnityEngine;
using UnityEngine.SceneManagement;

public class Proximascene : MonoBehaviour
{
    public bool wrapToFirst = false;

    public void LoadNextScene()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int total = SceneManager.sceneCountInBuildSettings;
        int next = current + 1;
        if (next >= total)
        {
            if (wrapToFirst) next = 0;
            else return;
        }
        SceneManager.LoadScene(next);
    }
}