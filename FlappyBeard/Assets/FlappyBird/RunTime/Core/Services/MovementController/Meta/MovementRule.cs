namespace FlappyBird.Rintime.Core.Services.BirdMovment.Meta
{
    public struct MovementRule
    {
        public MovementType Type { get; }
        public IBaseConfig Config { get; }
        
        public MovementRule(MovementType type, IBaseConfig config)
        {
            Type = type;
            Config = config;
        }
    }
}