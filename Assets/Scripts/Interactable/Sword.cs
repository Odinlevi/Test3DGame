using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Interactable
{
    private bool _isInteractionAllowed;
    private SphereCollider _collider;
    [SerializeField] private GameObject WeaponParent;

    // Start is called before the first frame update
    void Start()
    {
        _isInteractionAllowed = false;
        _collider = GetComponent<SphereCollider>();
        _collider.radius = radius;
        gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-50.0f, 50.0f), -0.3324797f, 
            UnityEngine.Random.Range(-70.0f, 20.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInteractionAllowed && Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("ThirdPersonPlayer"))
        {
            _isInteractionAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name.Equals("ThirdPersonPlayer"))
        {
            _isInteractionAllowed = false;
        }
    }

    public override void Interact()
    {
        foreach (var weaponObject in WeaponParent.GetComponentsInChildren<MeshRenderer>())
        {
            if (weaponObject.gameObject.name != "DobleSideSword")
            {
                weaponObject.enabled = false;
            }
            else
            {
                weaponObject.enabled = true;
            }
        }
        
        Destroy(gameObject);
        
    }
}
