using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float maxMoveSpeed;
    public float mouseSensivity;
	private Rigidbody _rb;
	private Vector3 _moveVelocity;

	void Start () 
	{		
		_rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
    {
        Move();
        Rotate();
    }
	private void Move()
    {
        // Getting input
        float keyboardHorizontal = Input.GetAxis("Horizontal");
        float keyboardVertical = Input.GetAxis("Vertical");        

        // Calculating relative rotation
        Quaternion referenceRelativeRotation = Quaternion.FromToRotation(Vector3.forward, transform.forward);                
        
        // Processing input data
        Vector3 inputDirection = referenceRelativeRotation * new Vector3(keyboardHorizontal, 0f, keyboardVertical);
        Vector3 rawMoveVelocity = inputDirection * maxMoveSpeed * inputDirection.magnitude;
        _moveVelocity = Vector3.ClampMagnitude(rawMoveVelocity, maxMoveSpeed);

        // Aplying move effects to objects       
        _rb.velocity = _moveVelocity;
    }
    private void Rotate()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X");
        Vector3 inputBodyRotation = new Vector3(0f, mouseHorizontal * mouseSensivity, 0f);
        Vector3 bodyRotation = _rb.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(inputBodyRotation + bodyRotation);
    }
}
