using System.Collections;
using TMPro;
using UnityEngine;

namespace General
{
    public class StopWatch : MonoBehaviour
    {
        
       
        public TextMeshProUGUI timer; 
        [SerializeField] private float time;
        private float _mSec; 
        private float _sec;
        private float _min;
        
        // Start is called before the first frame update

        private void Start()
        {
            StartCoroutine(StopWatchFunc());
        }


        public IEnumerator StopWatchFunc()
        {
            while (true)
            {
                time += Time.deltaTime;
                _mSec = (int) ((time - (int) time) * 100);
                _sec = (int) (time % 60);
                _min = (int) (time / 60 % 60);
                
                timer.text = $"{_min:00}:{_sec:00}";
                yield return null;
            }

            
        }
    }
}
