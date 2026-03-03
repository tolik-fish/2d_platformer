using UnityEngine;

public class LevelInitialize : MonoBehaviour
{
    [SerializeField] private Hero _heroPrefab;
    [SerializeField] private Transform _startPostion;

    private Hero _heroInstance;

    private void Awake()
    {
        _heroInstance = Instantiate(_heroPrefab, _startPostion.position, _startPostion.localRotation);
        InitializeHero();
    }

    private void InitializeHero()
    {
        IMover mover = new Mover(_heroInstance.Rigidbody, _heroInstance.Setting);
        IJumper jumper = new Jumper(_heroInstance.Rigidbody, _heroInstance.Setting);
        IAttacker attacker = new Attacker(_heroInstance.Setting, _heroInstance.Sprite, _heroInstance.transform);

        HeroStateMachineFactory heroStateMachineFactory = new HeroStateMachineFactory(_heroInstance.Animator, mover, jumper, attacker, _heroInstance.GroundDetector, _heroInstance.PlayerInput);

        _heroInstance.Construct(heroStateMachineFactory.Create());
    }
}