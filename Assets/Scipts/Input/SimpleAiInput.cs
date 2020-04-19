namespace Scipts.Input
{
    public class SimpleAiInput : PlayerInput
    {
        public float rotation = 0f;
    
        public float acceleration = 0f;

        public void Update()
        {
            Acceleration = acceleration;
            Rotation = Rotation;
        }
    }
}
