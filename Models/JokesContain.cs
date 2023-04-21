namespace Nicholas_Jokes_App.Models
{
    public class JokesContain
    {
        public int JokeID { get; set; }

        public string JokeAnswer { get; set; }

        public string JokeQuestion { get; set; }

        public JokesContain()
        {
            JokeQuestion = string.Empty;
            JokeAnswer = string.Empty;
        }

    }
}
