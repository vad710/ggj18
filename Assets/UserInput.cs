using UnityEngine;

public class UserInput : MonoBehaviour
{

    public Movement PlayerCharacter;

    public Target TestTarget;

    private bool _started;

	// Update is called once per frame
	public void Update ()
	{
	    if (!_started  && (Input.GetKeyDown(KeyCode.Return) || Input.touchCount > 0))
	    {
	        if (PlayerCharacter != null)
	        {
	            _started = true;
                PlayerCharacter.StartMoving();
	        }
	    }
        else if (Input.GetKeyDown(KeyCode.Space))
	    {
	        if (this.TestTarget != null)
	        {
                Debug.Log("Generating test platform");
                this.TestTarget.GeneratePlatform();
	        }
	    }
	}
}
