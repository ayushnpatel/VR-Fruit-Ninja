using UnityEngine;
using System.Collections.Generic;



public class DemoManager : MonoBehaviour
{
	#region fields
		List<DemoFruit> demoFruits = new List<DemoFruit>();
		bool isDragging;
		Vector2 mouseVelocity;
		DemoFruit slicedFruit;
	#endregion
	
	
	
	DemoFruit CheckForFruitUnderCursor()
	{
		RaycastHit hit;
		if ( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hit, 1 << 9 ) )
			return hit.collider.gameObject.GetComponent<DemoFruit>();
		else
			return null;
	}
	
	
	
	void Start ()
	{
		foreach ( ExplodingFruit explodingFruit in FindObjectsOfType( typeof(ExplodingFruit)))
		{
			DemoFruit demoFruit = explodingFruit.gameObject.AddComponent<DemoFruit>();
			demoFruits.Add ( demoFruit );
			demoFruit.gameObject.layer = 9;
		}
	}
	
	
	
	void Update()
	{
		if ( Input.GetMouseButtonDown( 0 ) )
		{
			DemoFruit fruitUnderCursor = CheckForFruitUnderCursor();
			mouseVelocity = Vector2.zero;
			
			if ( fruitUnderCursor != null )
				fruitUnderCursor.Explode( );
			else
				isDragging = true;
		}
		else if ( Input.GetMouseButtonUp( 0 ))
		{
			DemoFruit fruitUnderCursor = CheckForFruitUnderCursor();
			if ( fruitUnderCursor != null )
				fruitUnderCursor.Explode( 0.5f * mouseVelocity );
			isDragging = false;
			mouseVelocity = Vector2.zero;
			slicedFruit = null;
		}
		else if ( isDragging )
		{
			Vector2 currentMouseVelocity = new Vector2(	Input.GetAxis("Mouse X"),
																					Input.GetAxis("Mouse Y") ) / Time.deltaTime;
			mouseVelocity = Vector2.Lerp(mouseVelocity, currentMouseVelocity, Time.deltaTime * 10);
			DemoFruit fruitUnderCursor = CheckForFruitUnderCursor();
			if ( slicedFruit != null && slicedFruit != fruitUnderCursor )
			{
				slicedFruit.Explode( 0.1f * mouseVelocity );
				isDragging = false;
				mouseVelocity = Vector2.zero;
				slicedFruit = null;
			}
			else if ( slicedFruit == null && fruitUnderCursor != null )
			{
				slicedFruit = fruitUnderCursor;
			}
		}
	}
	
	
}
