using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private static SceneTransition instance;

    private Animator _component;
    private AsyncOperation _loadingSceneOperation;
    private float _delay = 3f;
    public static void SwitchToScene(string sceneName)
    {
        instance._component.SetTrigger("Start");
        instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        instance._loadingSceneOperation.allowSceneActivation = false;
    }

    private void Start()
    {
        instance = this;
        _component = GetComponent<Animator>();
    }

    private void Change()
    {
        instance._loadingSceneOperation.allowSceneActivation = true;
    }

    public void OnAnimationOver()
    {
        Invoke("Change", _delay);
    }
}
