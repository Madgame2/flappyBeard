namespace FlappyBird.Rintime.Core.Services.BirdMovment.Meta
{
    public struct MovementRule
    {
        public MovementType Type { get; }
        public IBaseMoveConfig Config { get; }
        
        public MovementRule(MovementType type, IBaseMoveConfig config)
        {
            Type = type;
            Config = config;
        }
    }
}