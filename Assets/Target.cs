using UnityEngine;

public class Target : MonoBehaviour 
{
    public void GeneratePlatform()
    {

        const float xScale = 0.4569838f;
        const float zScale = 0.968372f;

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<Platform>();
        var collider = cube.GetComponent<Collider>();
        if (collider != null)
        {
            Destroy(collider);
        }
        
        cube.transform.localScale = new Vector3();
        cube.transform.parent = this.transform;


    }
	
}
