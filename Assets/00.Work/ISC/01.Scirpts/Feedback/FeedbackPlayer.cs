using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class FeedbackPlayer : MonoBehaviour
{
    private List<Feedback> _feedbacks;

    private void Awake()
    {
        _feedbacks = GetComponents<Feedback>().ToList();
    }

    public void PlayFeddback()
    {
        StopFeedback();
        _feedbacks.ForEach(t => t.PlayFeedback());
    }

    private void StopFeedback()
    {
        _feedbacks.ForEach(t => t.StopFeedback());
    }
}