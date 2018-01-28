using UnityEngine;

public class Movement : MonoBehaviour {



    public float Speed = 0.005f;

    private readonly float _interval = 0.05f;
    private float _nextInterval = 0f;
    private bool _isMoving = false;

    public void StartMoving()
    {
        _isMoving = true;
    }

    public void StopMoving()
    {
        _isMoving = false;
    }



    public void FixedUpdate ()
	{
	    if (_isMoving && Time.time > _nextInterval)
	    {
	        _nextInterval = Time.time + _interval;

            this.transform.localPosition = new Vector3(0f, this.transform.localPosition.y, this.transform.localPosition.z + Speed);
            
	    }
	}
}
