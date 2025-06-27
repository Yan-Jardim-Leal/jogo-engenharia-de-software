using UnityEngine;

public class MainMenuManager : MonoBehaviour
{   
    // Deuses da programação me perdoem por estar fazendo isso mas eu não tenho tempo
    public CanvasGroup mainMenuCanvasGroup; 
    public CanvasGroup optionsMenuCanvasGroup; 
    public CanvasGroup menuNomeCanvasGroup;
    public CanvasGroup menuInformacoes;
    public CanvasGroup menuAdmin;

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

        menuInformacoes.alpha = 0f;
        menuInformacoes.interactable = false;
        menuInformacoes.blocksRaycasts = false;

        menuAdmin.alpha = 0f;
        menuAdmin.interactable = false;
        menuAdmin.blocksRaycasts = false;

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

        menuInformacoes.alpha = 0f;
        menuInformacoes.interactable = false;
        menuInformacoes.blocksRaycasts = false;

        menuAdmin.alpha = 0f;
        menuAdmin.interactable = false;
        menuAdmin.blocksRaycasts = false;

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

        menuInformacoes.alpha = 0f;
        menuInformacoes.interactable = false;
        menuInformacoes.blocksRaycasts = false;

        menuAdmin.alpha = 0f;
        menuAdmin.interactable = false;
        menuAdmin.blocksRaycasts = false;

        menuNomeCanvasGroup.alpha = 1f;
        menuNomeCanvasGroup.interactable = true;
        menuNomeCanvasGroup.blocksRaycasts = true;
    }

    public void ShowInfoMenu()
    {
        mainMenuCanvasGroup.alpha = 0f;
        mainMenuCanvasGroup.interactable = false;
        mainMenuCanvasGroup.blocksRaycasts = false;

        optionsMenuCanvasGroup.alpha = 0f;
        optionsMenuCanvasGroup.interactable = false;
        optionsMenuCanvasGroup.blocksRaycasts = false;

        menuNomeCanvasGroup.alpha = 0f;
        menuNomeCanvasGroup.interactable = false;
        menuNomeCanvasGroup.blocksRaycasts = false;

        menuAdmin.alpha = 0f;
        menuAdmin.interactable = false;
        menuAdmin.blocksRaycasts = false;

        menuInformacoes.alpha = 1f;
        menuInformacoes.interactable = true;
        menuInformacoes.blocksRaycasts = true;
    }

    public void showAdminPassage()
    {   
        optionsMenuCanvasGroup.alpha = 0f;
        optionsMenuCanvasGroup.interactable = false;
        optionsMenuCanvasGroup.blocksRaycasts = false;

        menuAdmin.alpha = 1f;
        menuAdmin.interactable = true;
        menuAdmin.blocksRaycasts = true;
    }

    public void exitGame(){
        Debug.Log("O botão de sair foi clicado!");
        Application.Quit();
    }

}