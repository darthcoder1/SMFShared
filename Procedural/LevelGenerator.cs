using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SMF.Procedural
{

	public class GeneratorSettings
	{
		public int gridWidth;
		public int gridHeight;
		public int randomSeed;
	}

	public class GeneratedLevelGrid
	{
		public int gridWidth { get; private set; }
		public int gridHeight { get; private set; }

		public int[,] data;

		public GeneratedLevelGrid(int width, int height)
		{
			gridWidth = width;
			gridHeight = height;

			data = new int[gridWidth, gridHeight];
		}
	}

	public class LevelGenerator
	{
		public static GeneratedLevelGrid Generate(GeneratorSettings settings)
		{
			GeneratedLevelGrid level = new GeneratedLevelGrid(settings.gridWidth, settings.gridHeight);

			//Random rng = new Random(settings.randomSeed);

			for (int curHeight = 0; curHeight < settings.gridHeight; ++curHeight)
			{
				for (int i = 0; i < settings.gridWidth; ++i)
				{
					level.data[i, curHeight] = Random.Range(0, 2);// rng.Next(2);
				}
			}

			for (int curHeight = 0; curHeight < settings.gridHeight; ++curHeight)
			{
				string lineText = "";
				for (int i = 0; i < settings.gridWidth; ++i)
				{
					lineText += level.data[i, curHeight].ToString();
				}

				Debug.LogWarning(lineText + " - " + curHeight.ToString());
			}

			return level;
		}
	}
}