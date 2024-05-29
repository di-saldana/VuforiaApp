using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

	// Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Para PC
        {
            MoveToPosition(Input.mousePosition);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // Para móvil
        {
            MoveToPosition(Input.GetTouch(0).position);
        }
    }

    void MoveToPosition(Vector3 screenPosition)
    {
        Ray ray = cam.ScreenPointToRay(screenPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}
