using UnityEngine;
using System.Collections.Generic;

public class Tweener : MonoBehaviour
{
    // private Tween activeTween; // no longer needed
    private List<Tween> activeTweens = new List<Tween>();

    // check if transform already has an active tween
    public bool TweenExists(Transform target)
    {
        foreach (var tween in activeTweens)
        {
            if (tween.Target == target)
            {
                return true;
            }
        }
        return false;
    }

    // try to add a new tween
    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (!TweenExists(targetObject))
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        return false;
    }

    void Update()
    {
        // temporary list to mark finished tweens
        List<Tween> finishedTweens = new List<Tween>();

        foreach (var tween in activeTweens)
        {
            if (tween.Target == null) continue;

            float distance = Vector3.Distance(tween.Target.position, tween.EndPos);

            if (distance > 0.1f)
            {
                // fraction of journey completed
                float timeFraction = (Time.time - tween.StartTime) / tween.Duration;

                // cubic easing-in
                timeFraction = Mathf.Pow(timeFraction, 3);

                // lerp from startPos to endPos
                Vector3 newPos = Vector3.Lerp(tween.StartPos, tween.EndPos, timeFraction);
                tween.Target.position = newPos;
            }
            else
            {
                // snap to final and mark tween as finished
                tween.Target.position = tween.EndPos;
                finishedTweens.Add(tween);
            }
        }

        // remove all finished tweens
        foreach (var t in finishedTweens)
        {
            activeTweens.Remove(t);
        }
    }
}
