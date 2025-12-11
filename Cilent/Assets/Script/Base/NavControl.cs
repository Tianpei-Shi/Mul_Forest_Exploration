using UnityEngine;
using UnityEngine.AI;

public class NavControl : MonoBehaviour
{
    private NavMeshAgent agent;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        agent = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                // 设置NavMeshAgent的目标位置
                agent.SetDestination(hit.point);
			}
		}
    }
}
