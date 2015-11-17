using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SMF
{
	public class SpriteAnimationComponent : MonoBehaviour
	{
		public Vector2 panSpeed;

		private Vector2 currentOffset;
		private Renderer renderComponent;


		void Start()
		{
			renderComponent = GetComponent<Renderer>();
			Debug.Assert(renderComponent);

			renderComponent.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
			//for (int i = 0; i < renderComponent.sprite.uv.Length; ++i)
				//renderComponent.sprite.rect
		}

		void Update()
		{
			Vector2 offset = panSpeed * Time.deltaTime;
			currentOffset += offset;

			renderComponent.material.mainTextureOffset = currentOffset;
		}
	}
}
