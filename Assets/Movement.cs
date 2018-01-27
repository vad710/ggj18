using UnityEngine;

public class Movement : MonoBehaviour {



    public float Speed = 0.01f;

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



    public void Update ()
	{
	    if (_isMoving && Time.time > _nextInterval)
	    {
	        _nextInterval = Time.time + _interval;

            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + Speed);
            
	    }
	}
}
