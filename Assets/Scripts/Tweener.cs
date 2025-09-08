using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;

    void Update()
    {
        if (activeTween != null && activeTween.Target != null)
        {
            // distance check
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if (distance > 0.1f)
            {
                // fraction of journey completed
                float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;

                // cubic easing-in (slower start, faster finish)
                timeFraction = Mathf.Pow(timeFraction, 3);

                // lerp from startPos to endPos based on eased fraction
                Vector3 newPos = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);

                activeTween.Target.position = newPos;
            }
            else
            {
                // snap to final position and clear tween
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }
        }
    }


    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }
    }
}