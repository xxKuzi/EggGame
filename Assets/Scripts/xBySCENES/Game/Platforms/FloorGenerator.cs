using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{

	[SerializeField] GameObject floor;
	[SerializeField] GameObject movingPlatformShoe;		//this is the object the Shoe is spawned with
	[SerializeField] GameObject movingPlatform;
	[SerializeField] GameObject dangerFloor;	
	[SerializeField] GameObject coin;
	[SerializeField] private GameObject redBoxDrop;
	[SerializeField] GameObject trampoline;		
	[SerializeField] GameObject magnet;
	
	
	[SerializeField] Transform player;


	int spawnHeight = 50;
	int defSpawnHeight = 150;

	int shoeRate = 0; //Spawning rate

	int coinSpawn;
	private int specialCoinSpawn;
	private int specialCoinSpawnFrequency;
	
	int trampolineSpawn;
	int magnetSpawn;
	bool magnetActualSpawn;

	//NUMBER OF OBJECTS
	int nFloor = 50;     
	int nMovingFloor = 5;
	int nDangerFloor = 14;


	int firstFloor = 0;
	


	//It can spawn to each other

	//Width of screen
	float levelWidth = 5f;

	// How much is X increased of "floor"
	float floorMinY = 1; 
	float floorMaxY = 5;

	// How much is X increased of "movingFloor"	
	float movingFloorY = 30;
	

	// How much is X increased of "dangerFloor"
	float dangerFloorY = 10;
	

	Vector2 floorPosition = new Vector2();
	Vector2 coinPosition = new Vector2();

	Vector2 movingFloorPosition = new Vector2();

	Vector2 dangerFloorPosition = new Vector2();
	Vector2 magnetPosition = new Vector2();
	Vector2 trampolinePosition = new Vector2();
	void Start()
	{
		ResetSpecialCoinSpawnFrequency();
		Spawn();
	}
    private void Update()
    {
        if(player.position.y >= spawnHeight)
        {
			Spawn();
			spawnHeight += defSpawnHeight;
        }			
    }

    void ResetSpecialCoinSpawnFrequency()
    {
	    specialCoinSpawnFrequency = Random.Range(1, 3) + Random.Range(1, 3) + Random.Range(1, 3);
	    specialCoinSpawn = 0;
    }
	void Spawn()
	{

		//FLOOR | Coin

		//FIRST FLOOR
		if(firstFloor == 0)
        {
			floorPosition.x = Random.Range(-levelWidth, levelWidth);
			floorPosition.y += Random.Range(0, 2);
			Instantiate(floor, floorPosition, Quaternion.identity);
			floorPosition.y = -2;
			firstFloor++;
		}
		
		for (int i = 0; i < nFloor; i++)
			{
				floorPosition.x = Random.Range(-levelWidth, levelWidth);
				floorPosition.y += Random.Range(floorMinY, floorMaxY);
				Instantiate(floor, floorPosition, Quaternion.identity);

				coinSpawn++;


				if (coinSpawn == 5)
				{
					coinPosition.x = floorPosition.x;
					coinPosition.y = floorPosition.y + 0.7f;
					specialCoinSpawn++;
					if (specialCoinSpawn == specialCoinSpawnFrequency)
					{
						Instantiate(redBoxDrop, coinPosition, Quaternion.identity);
						ResetSpecialCoinSpawnFrequency();
					}
					else
					{
						Instantiate(coin, coinPosition, Quaternion.identity);	
					}
					
					
					coinSpawn = 0;
				}
			}


		//MOVING FLOORs 


		for (int i = 0; i < nMovingFloor; i++)
		{

			//MOVING FLOOR WITHOUT SHOE			
			movingFloorPosition.y += movingFloorY;
			movingFloorPosition.x = 0;
			Instantiate(movingPlatform, movingFloorPosition, Quaternion.identity);

			shoeRate++;

			//MOVING FLOOR WITH SHOE
			if(shoeRate == 9)
            {
				movingFloorPosition.y += movingFloorY;
				movingFloorPosition.x = 0;
				Instantiate(movingPlatformShoe, movingFloorPosition, Quaternion.identity);
				
				shoeRate = 0;
			}				
			


			

		}

		

		for (int i = 0; i < nMovingFloor; i++)
		{
			

		}

		//DANGER FLOOR | Magnet | Trampoline


		for (int i = 0; i < nDangerFloor; i++)
			{

				dangerFloorPosition.y += dangerFloorY;
				dangerFloorPosition.x = Random.Range(-levelWidth, levelWidth);
				Instantiate(dangerFloor, dangerFloorPosition, Quaternion.identity);

				magnetSpawn++;
				trampolineSpawn++;
				magnetActualSpawn = false;

				if (magnetSpawn == 15)
				{
					magnetPosition.x = dangerFloorPosition.x;
					magnetPosition.y = dangerFloorPosition.y + 0.7f;
					Instantiate(magnet, magnetPosition, Quaternion.identity);

					magnetSpawn = 0;
					magnetActualSpawn = true;

				}


				if (trampolineSpawn >= 20 && magnetActualSpawn == false)
				{
					trampolinePosition.x = dangerFloorPosition.x;
					trampolinePosition.y = dangerFloorPosition.y + 0.3f;
					Instantiate(trampoline, trampolinePosition, Quaternion.identity);

					trampolineSpawn = 0;

				}
			}
	}

}
