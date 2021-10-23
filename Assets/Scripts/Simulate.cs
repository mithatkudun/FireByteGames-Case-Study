using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulate : MonoBehaviour
{
    
    public GameObject YLS;
    public GameObject RLS;
    private Quaternion YLStargetrotation;
    private Quaternion RLStargetrotation;
    float YLSXCoord;
    float RLSXCoord;
    public bool simulateBool = false;
    bool startedSimulate = true;
    void Update()
    {   
        if(startedSimulate)
        {
            YLSXCoord = -YLS.transform.localEulerAngles.x;
            RLSXCoord = -RLS.transform.localEulerAngles.x;
            YLStargetrotation = Quaternion.Euler(YLSXCoord, YLS.transform.localEulerAngles.y + YLSXCoord, 89);
            RLStargetrotation = Quaternion.Euler(RLSXCoord, RLS.transform.localEulerAngles.y + -RLSXCoord, -89);
            if(YLS.transform.localEulerAngles.x < -80)
            {
                YLStargetrotation = Quaternion.Euler(-YLSXCoord, YLS.transform.localEulerAngles.y - 180, 0);
            }
            if(RLS.transform.localEulerAngles.x > 80)
            {
                RLStargetrotation = Quaternion.Euler(-RLSXCoord, RLS.transform.localEulerAngles.y + 180, 0);
            }
        }
        
        if (simulateBool)
            {
                YLS.transform.rotation = Quaternion.RotateTowards(YLS.transform.rotation, YLStargetrotation, 60f * Time.deltaTime);
                RLS.transform.rotation = Quaternion.RotateTowards(RLS.transform.rotation, RLStargetrotation, 60f * Time.deltaTime);
            }       
    }
    public void SimulateButton()
    {
        simulateBool = true;
        startedSimulate = false;
    }
}
