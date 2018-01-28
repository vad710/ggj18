using UnityEngine;

public class UserInput : MonoBehaviour
{

    public Movement PlayerCharacter;

    public Target TestTarget;

	// Update is called once per frame
	public void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Return))
	    {
	        if (PlayerCharacter != null)
	        {
                PlayerCharacter.StartMoving();
	        }
	    }
        else if (Input.GetKeyDown(KeyCode.Space))
	    {
	        if (this.TestTarget != null)
	        {
                this.TestTarget.GeneratePlatform();
	        }
	    }
	}
}
