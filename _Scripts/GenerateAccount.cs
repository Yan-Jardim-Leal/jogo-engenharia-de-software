using System.IO;
using UnityEngine;
using static LoginManager;

public class GenerateAccount : MonoBehaviour
{
    private string jsonFilePath;

    void Awake()
    {
        jsonFilePath = Path.Combine(Application.persistentDataPath, "professorData.json");
 
        SetupInitialCredentials();
    }

    private void SetupInitialCredentials()
    {
        if (!File.Exists(jsonFilePath))
        {
            Debug.Log("Arquivo não encontrado, gerando um novo...");

            LoginData defaultData = new LoginData();
            defaultData.username = "admin";
            defaultData.password = "senha123";

            string jsonData = JsonUtility.ToJson(defaultData, true);

            try
            {
                File.WriteAllText(jsonFilePath, jsonData);
                Debug.Log($"Ficheiro de login padrão criado com sucesso em: {jsonFilePath}");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Falha ao criar o ficheiro de login padrão: {e.Message}");
            }
        }
    }
}
