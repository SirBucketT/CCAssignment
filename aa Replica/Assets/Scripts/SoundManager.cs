using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    [SerializeField] AudioSource audioSource;


    public void ClickSound()
    {
        audioSource.Play();
    }
}
