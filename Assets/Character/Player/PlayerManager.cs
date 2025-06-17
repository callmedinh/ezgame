namespace Character.Player
{
    public class PlayerManager : CharacterManager
    {
        PlayerLocomotionManager playerLocomotionManager;
        public override void Awake()
        {
            base.Awake();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            base.Update();
            if (!IsOwner) return;
            playerLocomotionManager.HandleAllMovement();
        }
    }
}