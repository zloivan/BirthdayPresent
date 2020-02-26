using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    // Start is called before the first frame update
    void Start()
    {
        ClickSelect.OnChangeSelected += ClickSelectOnOnChangeSelected;
        startGameButton.onClick.AddListener(OnClickHandler);
    }

    public void OnClickHandler()
    {
        SceneManager.LoadScene("Game");
        if (SceneManager.GetSceneByName("UI").isLoaded == false)
        {
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
    }

    private void ClickSelectOnOnChangeSelected(Instance obj)
    {
        if (obj == null)
        {
            Invoke(nameof(HideStartGameButton), 0.1f);
        }
        else
        {
            startGameButton.gameObject.SetActive(true);
        }
    }

    private void HideStartGameButton()
    {
        startGameButton.gameObject.SetActive(false);
    }
}