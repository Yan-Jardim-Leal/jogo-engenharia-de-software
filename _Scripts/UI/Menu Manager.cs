using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public CanvasGroup mainMenuCanvasGroup; 
    public CanvasGroup optionsMenuCanvasGroup; 
    public CanvasGroup menuNomeCanvasGroup;

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        optionsMenuCanvasGroup.alpha = 0f;
        optionsMenuCanvasGroup.interactable = false;
        optionsMenuCanvasGroup.blocksRaycasts = false;

        menuNomeCanvasGroup.alpha = 0f;
        menuNomeCanvasGroup.interactable = false;
        menuNomeCanvasGroup.blocksRaycasts = false;

        mainMenuCanvasGroup.alpha = 1f;
        mainMenuCanvasGroup.interactable = true;
        mainMenuCanvasGroup.blocksRaycasts = true;
    }

    public void ShowOptionsMenu()
    {
        mainMenuCanvasGroup.alpha = 0f;
        mainMenuCanvasGroup.interactable = false;
        mainMenuCanvasGroup.blocksRaycasts = false;

        menuNomeCanvasGroup.alpha = 0f;
        menuNomeCanvasGroup.interactable = false;
        menuNomeCanvasGroup.blocksRaycasts = false;

        optionsMenuCanvasGroup.alpha = 1f;
        optionsMenuCanvasGroup.interactable = true;
        optionsMenuCanvasGroup.blocksRaycasts = true;
    }

    public void ShowPlayMenu()
    {
        mainMenuCanvasGroup.alpha = 0f;
        mainMenuCanvasGroup.interactable = false;
        mainMenuCanvasGroup.blocksRaycasts = false;

        optionsMenuCanvasGroup.alpha = 0f;
        optionsMenuCanvasGroup.interactable = false;
        optionsMenuCanvasGroup.blocksRaycasts = false;

        menuNomeCanvasGroup.alpha = 1f;
        menuNomeCanvasGroup.interactable = true;
        menuNomeCanvasGroup.blocksRaycasts = true;
    }

    public void exitGame(){
        Debug.Log("O botão de sair foi clicado!");
        Application.Quit();
    }

}