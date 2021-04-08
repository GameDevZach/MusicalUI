using UnityEngine;

namespace MusicalUI
{

    [RequireComponent(typeof(AudioSource))]
    public class MusicalSource : MonoBehaviour
    {
        public AudioClip audioClip;
        private AudioSource audioSource;

        public int detectedPitch;

        [SerializeField]
        private int[] halfstepsSong;
        private int currentNote = 0;
        [SerializeField]
        private int offsetHalfstep = 0;

        private float a = 1.059463094359f;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            detectedPitch = audioClip.frequency;
            
        }

        public void PlayMusicalSound()
        {
            audioSource.pitch = Mathf.Pow(a, halfstepsSong[currentNote] + offsetHalfstep);
            audioSource.PlayOneShot(audioClip);

            currentNote++;
            if (currentNote >= halfstepsSong.Length) currentNote = 0;
        }
    }

}