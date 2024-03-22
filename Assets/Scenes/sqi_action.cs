using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sqi_action : MonoBehaviour
{
    // 儲存與松鼠互動的動畫
    public Animator squ_ani_run;
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "cube")
        {

            squ_ani_run.SetBool("run", true);
            
        }
    }




    private void Update()
    {


        {
            // 播放松鼠跑的動畫

           

        }
    }
}