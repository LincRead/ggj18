using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [Header("Loading Indicator")]
    public GameObject loadingIndicatorPrefab;
    private GameObject _loadingIndicator;

    private string sceneName;

    private bool isLoading = false;
    private AsyncOperation asynchLoadScene;

    void Start()
    {
        isLoading = true;

        asynchLoadScene = SceneManager.LoadSceneAsync("dev_brig");
        asynchLoadScene.allowSceneActivation = false;

        _loadingIndicator = GameObject.Instantiate(
            loadingIndicatorPrefab,
            Vector3.zero,
            Quaternion.identity
        ) as GameObject;
    }

    void Update()
    {
        if (isLoading && asynchLoadScene.progress >= 0.9f)
        {
            LeanTween.alpha(_loadingIndicator.gameObject, 0.0f, 1.4f).setEase(LeanTweenType.easeInBack).setDelay(.2f);

            isLoading = false;

            Invoke("OpenWorld", 2f);
        }
    }

    void OpenWorld()
    {
        asynchLoadScene.allowSceneActivation = true;
    }
}
