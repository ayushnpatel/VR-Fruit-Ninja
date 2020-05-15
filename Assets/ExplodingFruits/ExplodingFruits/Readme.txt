Exploding Fruits


To use the fruits in your game, place them in the scene or instantiate the prefab at runtime, access the ExplodingFruits component and use its methods like this:

	ExplodingFruit explodingFruit = fruitObject.GetComponent<ExplodingFruit>();

	// By default, the fruit object and all of its parts will disappear 4 seconds
	// after the explosion. You can vary this time or set it to 0 if you want the
	// parts to stay around indefinitely:
	explodingFruit.destroyAfterSeconds = 5;

	// Make the fruit explode with a default force from its center:
	explodingFruit.Explode(); 			

	// Make the fruit explode from an impact with direction hitDirection and force hitForce:
	// (This will push the pieces in the direction of the impact)
	Vector3 hitVector = hitForce * hitDirection;
	Explode( hitVector );

	// Reset the exploded fruit object, so you can explode it again:
	explodingFruit.Reset();



For any support inquiries, please contact us: info@chromegekko.com







Credits:

Pumpkin Texture: Patrick Hoesly flickr.com
Watermelon/Pumpkin squash sounds: MWLANDI from freesound.org
