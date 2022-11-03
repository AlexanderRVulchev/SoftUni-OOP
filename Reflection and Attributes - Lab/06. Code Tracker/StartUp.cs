using System;


namespace AuthorProblem
{
    [Author("John")]
    public class StartUp
    {        
        public static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Jane")]
        public void Test() { }
    }
}
