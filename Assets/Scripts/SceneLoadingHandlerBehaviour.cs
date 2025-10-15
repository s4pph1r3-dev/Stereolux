using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;

public class SceneLoadingHandlerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    public async void LoadNextLevel()
    {
        await Task.Yield();
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) nextSceneIndex = 0;

        await SceneManager.LoadSceneAsync(nextSceneIndex);
    }

    public async void LoadPreviousLevel()
    {
        await Task.Yield();
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (nextSceneIndex < 0) nextSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        await SceneManager.LoadSceneAsync(nextSceneIndex);
    }
}
