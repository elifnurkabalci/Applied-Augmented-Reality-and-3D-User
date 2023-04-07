using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Part_one : MonoBehaviour
{

    public double[,] s = new double[4, 2] { { 1, 2 }, { 5, 3 }, { 4, 10 }, { 1, 6 } };
    public double[,] d = new double[4, 2] { { 1, 2 }, { 5, 3 }, { 4, 10 }, { 1, 6 } };

    void Homo()
    {
        double[,] hm = Homography.CalcHomographyMatrix(s, d);
        Debug.Log("Calculated Homography Matrix : \n\n");

        for (int i = 0; i < hm.GetLength(0); i++)
        {
            for (int j = 0; j < hm.GetLength(1); j++)
                Debug.Log(hm[i, j] + " ");
            Debug.Log("\n");
        }
    }
    private void Start()
    {
        Homo();
    }
}