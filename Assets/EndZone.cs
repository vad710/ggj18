
using UnityEngine;
using Vuforia;

public class EndZone : MonoBehaviour
{

    private const float SnapDistance = 0.01f; // 1 centimeter
    private const string EndZoneTag = "EndZoneTag";


    private readonly float _interval = 0.250f;
    private float _nextInterval = 0f;


    public void OnTriggerEnter(Collider other)
    {
        var movement = other.GetComponent<Movement>();

        if (movement != null)
        {
            movement.StopMoving();
        }

    }


    public bool IsActive
    {
        get
        {
            return this.ParentPlatform.IsActive;
        }
    }

    public Platform ParentPlatform { get; private set; }

    public void Start()
    {
        this.ParentPlatform = this.GetComponentInParent<Platform>();

        if (this.ParentPlatform == null)
        {
            Debug.LogError("EndZone does not have a Platform Parent");
        }

        this.tag = EndZoneTag;
    }

    public void Update()
    {
        if (IsActive && Time.time > _nextInterval)
        {
            _nextInterval = Time.time + _interval;

            //Debug.Log("Looking for other endzones...");

            var others = Physics.OverlapSphere(transform.position, SnapDistance);

            foreach (var other in others)
            {
                if (other.CompareTag(EndZoneTag))
                {
                    var otherEndZone = other.GetComponent<EndZone>();

                    if (this.ParentPlatform != otherEndZone.ParentPlatform)
                    {
                        //Inactivate this platform
                        this.ParentPlatform.IsActive = false;

                        //Activate the other platform
                        otherEndZone.ParentPlatform.IsActive = true;

                        //attach this platform to the parent platform
                        var parentPlatformTransform = this.ParentPlatform.transform;
                        parentPlatformTransform.parent = otherEndZone.ParentPlatform.transform.parent;
                        //parentPlatformTransform.position = new Vector3(0f,parentPlatformTransform.position.y,0f);
                        parentPlatformTransform.localRotation = Quaternion.identity;

                    }
                }
                
            }

        }
    }

}
