using UnityEngine;
using UnityEngine.Video;

public class FecharUI : MonoBehaviour
{
    
    public GameObject objeto;
    public VideoPlayer videoPlayer;

    public void desligar()
    {   
        //videoPlayer.Stop();
        
        Destroy(videoPlayer);

        objeto.SetActive(false);
        
    }

}
