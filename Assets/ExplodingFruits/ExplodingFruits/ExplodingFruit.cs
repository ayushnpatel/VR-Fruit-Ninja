using UnityEngine;
using System.Collections.Generic;



public class ExplodingFruit : MonoBehaviour
{

	#region fields
		
		// After having exploded, the fruit disappears after this many seconds.
		// Set this parameter to 0 if you don't want the fruit to disappear.
		public float destroyAfterSeconds = 4;
		
		// Determines the force of the explosion if you call Explode without parameters.
		public float defaultExplosionForce = 15;
	
		public bool hasExploded { get; private set; }
		
		float stateTime;
		new Transform transform;
		GameObject partsInnerRoot;
		Transform partsCommonRootTransform;
		GameObject splashEffect;
		AudioSource[] splashSounds;
	
		Dictionary<Transform, Vector3> origPositions = new Dictionary<Transform, Vector3>();
		Dictionary<Transform, Quaternion> origRotations = new Dictionary<Transform, Quaternion>();
	
	#endregion
	
	
	
	void Awake()
	{
		transform = base.transform;
		
		partsInnerRoot = transform.Find("Parts inner").gameObject;
		partsCommonRootTransform = transform.Find("Parts common");
		splashEffect = transform.Find("SplashEffect").gameObject;
		splashSounds = GetComponentsInChildren<AudioSource>();
		
		foreach ( Transform partTransform in partsInnerRoot.transform )
		{
			origPositions[ partTransform ] = partTransform.localPosition;
			origRotations[ partTransform ] = partTransform.localRotation;
		}
		
		if ( partsCommonRootTransform != null )
			foreach ( Transform partTransform in partsCommonRootTransform )
			{
				origPositions[ partTransform ] = partTransform.localPosition;
				origRotations[ partTransform ] = partTransform.localRotation;
			}
	}
	
	
	
	void Deactivate()
	{
		Destroy ( gameObject );
	}
	
	
	
	public void Explode ( Vector3? forceVector = null )
	{
		if ( hasExploded )
			return;
			
		splashSounds[ UnityEngine.Random.Range(0, splashSounds.Length ) ].Play();
		
		float force = forceVector.HasValue ? forceVector.Value.magnitude : defaultExplosionForce;
		Vector3 hitForce = forceVector ?? Vector3.zero;
	
		//*** Split into parts
		{
			GetComponent<Renderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
			partsInnerRoot.SetActive( true );
			
			foreach ( Transform partTransform in origPositions.Keys )
			{
				MeshCollider meshCollider = partTransform.GetComponent<Collider>() as MeshCollider;
				if ( meshCollider != null )
					meshCollider.convex = true;
				Vector3 offsetVector = partTransform.position - transform.position;
				float offset = offsetVector.magnitude;
				Vector3 explodeDirection = ( offset > 0 )		?	( offsetVector / offset )
																				:	partTransform.forward;
				
				Vector3 explodeForce = 0.5f * explodeDirection * force;
				Rigidbody rigidbody = partTransform.GetComponent<Rigidbody>();
				rigidbody.isKinematic = false;
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
				
				rigidbody.AddForce( hitForce + explodeForce );
				rigidbody.AddTorque( Vector3.Cross( partsInnerRoot.transform.up, explodeDirection ));
			}
		}
		
		splashEffect.transform.rotation = Quaternion.identity;
		
		foreach ( ParticleSystem particleSystem in splashEffect.GetComponentsInChildren<ParticleSystem>() )
		{
			particleSystem.Clear();
			if (forceVector.HasValue)
			{
				var vel = particleSystem.velocityOverLifetime;
				vel.enabled = true;
				Vector3 velocity = forceVector.Value / force;
				vel.x = velocity.x;
				vel.y = velocity.y;
				vel.z = velocity.z;
			}
			particleSystem.Play();
		}

		if ( destroyAfterSeconds > 0 )
			Invoke("Deactivate", destroyAfterSeconds);
			
		hasExploded = true;
	}
	
	
	
	public void Reset()
	{
		foreach ( Transform partTransform in origPositions.Keys )
		{
			partTransform.localPosition = origPositions[ partTransform ];
			partTransform.localRotation = origRotations[ partTransform ];
		}
		
		if ( partsCommonRootTransform != null )
			foreach ( Transform partTransform in partsCommonRootTransform )
				partTransform.GetComponent<Rigidbody>().isKinematic = true;
		
		partsInnerRoot.SetActive( false );
		GetComponent<Renderer>().enabled = true;
		GetComponent<Collider>().enabled = true;
		hasExploded = false;
	}
	
	

}
