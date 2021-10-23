using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    public  GameObject pipe; 
    float timer=0;
    public float timeDiff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;//프레임당 흘러가는 시간(초)
        if (timer>timeDiff){ //1초가 경과했을때
            GameObject newpipe = Instantiate(pipe);
            newpipe.transform.position = new Vector3(0, Random.Range(-3f, 2f), 0);
            timer=0;
            Destroy(newpipe, 5.0f);
        }

    }
}
