using General;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyBaseMovement : SingletonMonoBehavior<EnemyBaseMovement>
    {
        private Transform _target;

        private NavMeshAgent _navMeshAgent;
        
        private SpriteRenderer _spriteRenderer;
        
        public override void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindWithTag("Player").transform;
        }

        // Start is called before the first frame update
        private void Start()
        {
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateRotation();
            _navMeshAgent.SetDestination(_target.position);
        }

        private void UpdateRotation()
        {
            if (_navMeshAgent.desiredVelocity.x > 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_navMeshAgent.desiredVelocity.x < 0)
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
