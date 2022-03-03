namespace ClubManagement.TestApp
{
    public abstract class ChoiceSystemBase
    {
        protected bool CorrectChoiceMade;

        public ChoiceSystemBase()
        {
            CorrectChoiceMade = true;
        }

        protected void ResetChoiceMade()
        {
            CorrectChoiceMade = true;
        }

        protected void ChoiceMadeIncorrectly()
        {
            CorrectChoiceMade = false;
        }
    }
}
