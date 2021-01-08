    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Video;
     
    public class videomanager : MonoBehaviour {

         [SerializeField] VideoClip[] vids;
         VideoPlayer vp;
         int m_next;
      public void PlayNext()
    {
        if(m_next < vids.Length)
        {
            vp.clip = vids[m_next++];
            vp.Play();
        }
    }
 
    void Start()
    {
        vp = gameObject.GetComponent<VideoPlayer>();
    }
    }
