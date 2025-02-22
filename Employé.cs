namespace UsingCollectionsDemo
{
    public class Étudiant
    {
        public string NO { get; set; }
        public string Prénom { get; set; }
        public string Nom { get; set; }
        public double NoteCC { get; set; }
        public double NoteDevoir { get; set; }

        public double Moyenne => (NoteCC * 0.33) + (NoteDevoir * 0.67);
    }
}