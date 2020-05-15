using UnityEngine;
using System.Collections;



public class DemoFruit : MonoBehaviour
{
	#region fields
	
		enum State {
			ShowingFruit,
			ExplodingFruit
		}
		State state = State.ShowingFruit;
	
		Vector3 rotationAxis;
		float kRotationSpeed;
		ExplodingFruit explodingFruit;
	
	
	#endregion
	
	
	void Awake()
	{
		rotationAxis = UnityEngine.Random.onUnitSphere;
		kRotationSpeed = 25 * UnityEngine.Random.Range( 8.0f, 12.0f );
		explodingFruit = GetComponent<ExplodingFruit>();
	}
	
	
	
	public void Explode( Vector3? forceVector = null )
	{
		if ( state != State.ShowingFruit )
			return;

		explodingFruit.Explode( forceVector );
		state = State.ExplodingFruit;
		Invoke("Reset", 4);
	}




	void Reset()
	{
		if (explodingFruit == null)
			explodingFruit = GetComponent<ExplodingFruit>();

		explodingFruit.Reset();
		state = State.ShowingFruit;
	}
	
	
	
	void Update()
	{
		if ( state == State.ShowingFruit )
			transform.Rotate( rotationAxis, Time.deltaTime * kRotationSpeed );
	}

}
