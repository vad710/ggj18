using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{

    public Movement PlayerCharacter;
	
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
	}
}
