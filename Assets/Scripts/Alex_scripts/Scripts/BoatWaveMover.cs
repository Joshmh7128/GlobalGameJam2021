using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Alex_scripts
{
	public class BoatWaveMover : MonoBehaviour
	{
		private Vector3 _castOrigin;
		[SerializeField]
		private float castLength = 0.5f;
		
		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			_castOrigin = transform.position;
			RaycastHit hit;
			Debug.DrawRay(transform.position, Vector3.down * 50f);
			if (Physics.Raycast(_castOrigin, Vector3.down, out hit, castLength))		// The raycast hit a surface. Next is to determine if the surface should affect pitch, and adjust the normal
			{
				transform.up = hit.normal;
				Debug.DrawRay(hit.point, hit.normal);
			}
		}
	}
}
