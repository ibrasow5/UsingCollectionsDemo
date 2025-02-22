using System;
using System.Collections;

namespace UsingCollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstÉtudiants = new SortedList();
            double sommeMoyennes = 0;
            int nombreÉtudiants = 0;

            Console.Write("Combien d'étudiants voulez-vous entrer ? ");
            int nombre = int.Parse(Console.ReadLine());

            for (int i = 0; i < nombre; i++)
            {
                Console.Write("\nNuméro d'Ordre: ");
                string no = Console.ReadLine();

                Console.Write("Prénom: ");
                string prénom = Console.ReadLine();

                Console.Write("Nom: ");
                string nom = Console.ReadLine();

                Console.Write("Note Contrôle Continu: ");
                double noteCC = double.Parse(Console.ReadLine());

                Console.Write("Note Devoir: ");
                double noteDevoir = double.Parse(Console.ReadLine());

                Étudiant etudiant = new Étudiant()
                {
                    NO = no,
                    Prénom = prénom,
                    Nom = nom,
                    NoteCC = noteCC,
                    NoteDevoir = noteDevoir
                };

                lstÉtudiants.Add(no, etudiant);
                sommeMoyennes += etudiant.Moyenne;
                nombreÉtudiants++;
            }

            Console.Write("\nChoisissez le nombre de lignes par page (1-15) : ");
            int lignesParPage;
            while (true)
            {
                lignesParPage = int.Parse(Console.ReadLine());
                if (lignesParPage >= 1 && lignesParPage <= 15)
                    break;
                Console.Write("Valeur invalide. Entrez un nombre entre 1 et 15 : ");
            }

            Console.WriteLine("\nAppuyez sur Entrée pour afficher la liste des étudiants...");
            Console.ReadLine();

            int ligneActuelle = 0;
            int page = 1;

            foreach (DictionaryEntry entry in lstÉtudiants)
            {
                Étudiant etudiant = (Étudiant)entry.Value;
                Console.WriteLine($"NO: {etudiant.NO}, Prénom: {etudiant.Prénom}, Nom: {etudiant.Nom}, " +
                                  $"NoteCC: {etudiant.NoteCC}, NoteDevoir: {etudiant.NoteDevoir}, Moyenne: {etudiant.Moyenne:F2}");

                ligneActuelle++;

                if (ligneActuelle % lignesParPage == 0)
                {
                    Console.WriteLine($"\n--- Page {page} --- Appuyez sur Entrée pour continuer ou tapez 'q' pour quitter.");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "q")
                        return;
                    page++;
                }
            }

            Console.WriteLine($"\nMoyenne de la classe: {(sommeMoyennes / nombreÉtudiants):F2}");
            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadLine();
        }
    }
}
