using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance; // ��������� �������


    void Awake()
    {
      
        // ������, ��������� ������������� ����������
        if (instance != null)
        {
            Destroy(gameObject);
           
        }
        else
        {
           
            instance = this;
            DontDestroyOnLoad(transform.gameObject);

        }
      


    }

    
}
