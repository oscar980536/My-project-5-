using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sqi_action : MonoBehaviour
{
    // �x�s�P�Q�����ʪ��ʵe
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
            // ����Q���]���ʵe

           

        }
    }
}