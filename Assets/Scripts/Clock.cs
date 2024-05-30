using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private Transform hoursArm, minutesArm, secondsArm;
    private const float HourToDegree = -30f;
    private const float MinuteToDegree = -6f;
    private const float SecondToDegree = -6f;

    void Start()
    {
        //initalizing the clock
        UpdateArms(DateTime.Now.TimeOfDay);
    }

    void Update()
    {
        UpdateArms(DateTime.Now.TimeOfDay);
    }

    private void UpdateArms(TimeSpan newTime)
    {
        hoursArm.localRotation = Quaternion.Euler(0f, 0f, HourToDegree * (float)newTime.TotalHours);
        minutesArm.localRotation = Quaternion.Euler(0f, 0f, MinuteToDegree * (float)newTime.TotalMinutes);
        secondsArm.localRotation = Quaternion.Euler(0f, 0f, SecondToDegree * (float)newTime.TotalSeconds);
    }
}
