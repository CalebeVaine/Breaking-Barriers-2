using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    [Header("Configuração de Áudio")]
    [Tooltip("O clipe de áudio para tocar.")]
    public AudioClip backgroundMusic;

  
    [Range(0f, 1f)] 
    [Tooltip("Volume da música de fundo (0.0 = mudo, 1.0 = máximo).")]
    public float musicVolume = 0.5f;

    private AudioSource audioSource;

    void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

      

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.volume = musicVolume;

        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }


    public void SetVolume(float newVolume)
    {
        musicVolume = newVolume;
        if (audioSource != null)
        {
            audioSource.volume = musicVolume;
        }
    }

 
    private void Update()
    {
        if (audioSource != null && audioSource.volume != musicVolume)
        {
            audioSource.volume = musicVolume;
        }
    }
}