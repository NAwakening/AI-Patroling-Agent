using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ReloadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
