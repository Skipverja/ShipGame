namespace Scipts.Input
{
    public interface IPlayerInput
    {
        float Rotation { get; set; }
        
        float Acceleration { get; set; }
        
        bool Shooting { get; }
    }
}