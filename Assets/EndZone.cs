
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


    /// <summary>
    /// Parent platform is active when the Player Character is on platform
    /// </summary>
    public bool IsParentPlatformActive
    {
        get
        {
            return this.ParentPlatform.IsActive;
        }
    }

    /// <summary>
    /// EndZone is disabled once it has been attached to another location
    /// </summary>
    public bool Disabled { get; private set; }

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

    public void FixedUpdate()
    {
        if (IsParentPlatformActive && Time.time > _nextInterval)
        {
            _nextInterval = Time.time + _interval;

            //Debug.Log("Looking for other endzones...");

            var others = Physics.OverlapSphere(transform.position, SnapDistance);

            foreach (var other in others)
            {
                if (other.CompareTag(EndZoneTag))
                {
                    var otherEndZone = other.GetComponent<EndZone>();

                    if (this.ParentPlatform != otherEndZone.ParentPlatform && !otherEndZone.Disabled)
                    {
                        Debug.Log("Tranfering platform and locking position");

                        //Disable this endzone
                        this.Disabled = true;

                        //Inactivate this platform
                        this.ParentPlatform.IsActive = false;

                        //Activate the other platform
                        otherEndZone.ParentPlatform.IsActive = true;
                        
                        //attach this platform to the parent platform
                        var parentPlatformTransform = this.ParentPlatform.transform;
                        var otherPlatformTransform = otherEndZone.ParentPlatform.transform;

                        parentPlatformTransform.parent = otherEndZone.ParentPlatform.transform.parent;
                        parentPlatformTransform.localRotation = Quaternion.identity;
                        
                        
                        //aligning top...
                        var topOtherCube = otherPlatformTransform.localPosition.y + (otherPlatformTransform.localScale.y / 2);
                        var newHightOfCube = topOtherCube - (parentPlatformTransform.localScale.y / 2);

                        parentPlatformTransform.localPosition = new Vector3(0f,
                            newHightOfCube, parentPlatformTransform.localPosition.z);


                    }
                }
                
            }

        }
    }

}
