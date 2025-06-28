using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.UI;
using System.Collections; 


public class LoginManager : MonoBehaviour
{
    [Header("Refer�ncias da UI")]
    [Tooltip("O campo de input para o nome de usu�rio")]
    [SerializeField] private TMP_InputField userInputField;

    [Tooltip("O campo de input para a senha")]
    [SerializeField] private TMP_InputField passwordInputField;

    [Header("Configura��es de Navega��o")]
    [Tooltip("O nome da cena a ser carregada se o login for bem-sucedido")]
    [SerializeField] private string sceneNameToLoad = "AdminPanel";

    [Header("Painel de Notifica��o")]
    [Tooltip("O GameObject principal do painel de notifica��o")]
    [SerializeField] private GameObject notificationPanel;
    [Tooltip("O texto dentro do painel de notifica��o")]
    [SerializeField] private TextMeshProUGUI notificationText;
    [Tooltip("O bot�o 'OK' do painel de notifica��o")]


    private string jsonFilePath;
    private Coroutine notificationCoroutine;

    [System.Serializable]
    public class LoginData
    {
        public string username;
        public string password;
    }
    void Start()
    {     
        jsonFilePath = Path.Combine(Application.persistentDataPath, "professorData.json");  
    }

    public void CheckLogin()
    {
       
      
        if (!File.Exists(jsonFilePath))
        {
            ShowError("Erro: Arquivo de dados n�o encontrado.");
            return;
        }

        try
        {
            string jsonData = File.ReadAllText(jsonFilePath);

            LoginData savedData = JsonUtility.FromJson<LoginData>(jsonData);

            string currentUsername = userInputField.text;
            string currentPassword = passwordInputField.text;

            if (currentUsername == savedData.username && currentPassword == savedData.password)
            {
                Debug.Log("Login bem-sucedido!");
                SceneManager.LoadScene("_Scenes/Menu Professor");
            }
            else
            {
                ShowNotification("Utilizador ou senha incorretos.");
                ShowError("Usu�rio ou senha incorretos.");
            }
        }
        catch (System.Exception e)
        {
            ShowError($"Erro ao ler o arquivo: {e.Message}");
        }
    }
    private void ShowNotification(string message)
    {
        Debug.LogError(message);
     
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }
        
        notificationCoroutine = StartCoroutine(NotificationCoroutine(message));
    }

    private IEnumerator NotificationCoroutine(string message)
    {
 
        if (notificationPanel != null)
        {
            notificationText.text = message;
            notificationPanel.SetActive(true);
        }

        yield return new WaitForSeconds(4f);

        if (notificationPanel != null)
        {
            notificationPanel.SetActive(false);
        }

        notificationCoroutine = null;
    }

    public void CloseNotificationPanel()
    {
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
            notificationCoroutine = null;
        }

        if (notificationPanel != null)
        {
            notificationPanel.SetActive(false);
        }
    }

    private void ShowError(string message)
    {
        Debug.LogError(message);    
    }
}
