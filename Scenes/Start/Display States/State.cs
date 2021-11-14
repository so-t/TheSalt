namespace Start_Screen
{
    public abstract class State
    {
        // Private variables
        private Display display;
        
        // Public variables

        public abstract State Parse(string str);
    }
}