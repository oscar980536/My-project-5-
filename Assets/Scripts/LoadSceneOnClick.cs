using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    // 将要加载的场景名称
    public string sceneToLoad = "Scene0.5";

    // 在按钮点击时调用的方法
    public void LoadSceneOnClickHandler()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
