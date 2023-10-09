using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ransac : MonoBehaviour
{
    Vector3 calculate_mean(GameObject[] obj)
    {
        float x_data = 0;
        float y_data = 0;
        float z_data = 0;

        for(int i = 0; i < obj.Length; i++)
        {
            x_data += obj[i].gameObject.transform.position.x;
            y_data += obj[i].gameObject.transform.position.y;
            z_data += obj[i].gameObject.transform.position.z;
        }
        Vector3 neww = new Vector3(x_data / obj.Length, y_data / obj.Length, z_data / obj.Length);
        return neww;
    }
    void RigidTransformation(GameObject[] collection1, GameObject[] collection2)
    {
        Vector3 t1 = calculate_mean(collection1);
        Vector3 t2 = calculate_mean(collection2);

        float[ , ] T1 = { {0, 0, 0, -t1.x },
                          {0, 0, 0, -t1.y },
                          {0, 0, 0, -t1.z },
                          {0, 0, 0, 0 } };

        float[ , ] T2 = { {0, 0, 0, t2.x },
                          {0, 0, 0, t2.y },
                          {0, 0, 0, t2.z },
                          {0, 0, 0, 0 } };

        float[ , ] C = { {0, 0, 0}, {0, 0, 0}, {0, 0, 0}};
        
        
    }
    void G_RigidTransformation(GameObject[] collection1, GameObject[] collection2)
    {

    }
    void ButtonAction(GameObject[] collection1, GameObject[] collection2)
    {
        Button first_button = gameObject.AddComponent<Button>();
        Button second_button = gameObject.AddComponent<Button>();
        //first_button.onClick.AddListener(RigidTransformation(collection1,collection2));
        //second_button.onClick.AddListener(G_RigidTransformation(collection1,collection2));

    }
    void ReadFile()
    {
        GameObject[] collection1, collection2;
        StreamReader reader1, reader2;
        reader1 = new StreamReader("C:/Users/e.kabalci2018/Desktop/AR2/new_one/data1.txt");
        reader2 = new StreamReader("C:/Users/e.kabalci2018/Desktop/AR2/new_one/data2.txt");

        int n1 = (int)(reader1).Read() -48;
        int n2 = (int)(reader2).Read() -48;

        collection1 = new GameObject[n1];
        collection2 = new GameObject[n2];

        for (int i = 0; i < n1; i++)
        {
            GameObject cubeObject1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            float first_pcd_X = (float)(reader1).Read();
            float first_pcd_Y = (float)(reader1).Read();
            float first_pcd_Z = (float)(reader1).Read();
           
            cubeObject1.transform.localPosition = new Vector3(first_pcd_X, first_pcd_Y, first_pcd_Z);
            cubeObject1.transform.localScale = new Vector3(1, 1, 1);
            cubeObject1.GetComponent<MeshRenderer>().material.color = Color.red;

            collection1[i] = cubeObject1;
        }
        for (int i = 0; i < n2; i++)
        {
            GameObject cubeObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            float second_pcd_X = (float)(reader2).Read();
            float second_pcd_Y = (float)(reader2).Read();
            float second_pcd_Z = (float)(reader2).Read();

            cubeObject2.transform.localPosition = new Vector3(second_pcd_X, second_pcd_Y, second_pcd_Z);
            cubeObject2.transform.localScale = new Vector3(1, 1, 1);
            cubeObject2.GetComponent<MeshRenderer>().material.color = Color.blue;

            collection2[i] = cubeObject2;
        }
        reader1.Close();
        reader2.Close();
        reader1.Dispose();
        reader2.Dispose();
        ButtonAction(collection1, collection2);
    }

    void Start()
    {
        ReadFile();
    }


}
