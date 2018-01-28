using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject PlatformPrefab;

    public void GeneratePlatform()
    {
        if (PlatformPrefab != null)
        {
            

            var newPlatform = Instantiate(PlatformPrefab, this.transform);
            
            var platform = newPlatform.GetComponent<Platform>();
            platform.ParentTarget = this;

            var newHeight = Random.Range(0.2f, 0.75f);
            newPlatform.transform.localScale = new Vector3(newPlatform.transform.localScale.x, newHeight, newPlatform.transform.localScale.z);
            newPlatform.transform.localPosition = new Vector3(newPlatform.transform.localPosition.x,newHeight/2, newPlatform.transform.localPosition.z);
        }
    }
	
}
