using System;
using System.Collections.Generic;
using System.Linq;

namespace TPMoyennes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais");
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                       random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.Moyenne(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.Moyenne() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.Moyenne(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.Moyenne() + "\n");
            Console.Read();

        }
    }
}
// Classes fournies par HNI Institut
class Note
{
    public int matiere { get; private set; }
    public float note { get; private set; }
    public Note(int m, float n)
    {
        matiere = m;
        note = n;
    }
}
// Classes additionnelles
class Classe
{
    public Classe(string nomclasse) { nomClasse = nomclasse; }
    public string nomClasse;
    public decimal Moy;
    public int nbNote = 5;


    //Liste des élèves
    public List<Eleve> eleves = new List<Eleve>();
    public void ajouterEleve(string prenom, string nom)
    {
        eleves.Add(new Eleve() { prenom = prenom, nom = nom });
    }

    //Liste des matières
    public List<string> matieres = new List<string>();
    public void ajouterMatiere(string nomMatiere)
    {
        matieres.Add(nomMatiere);
    }

    //Moyenne classe par matière
    public decimal Moyenne(int numMatiere)
    {
        List<decimal> moyClasse = new List<decimal>();
        for (int i = 0; i < eleves.Count(); i++)
        {
            moyClasse.Add(eleves[i].Moyenne(numMatiere));
        }
        Moy = Math.Round(moyClasse.Average(), 2);
        return Moy;
        //return 6;
    }

    //Moyenne classe générale
    public decimal Moyenne()
    {
        List<decimal> moyClasseGen = new List<decimal>();
        for (int numMat = 0; numMat < matieres.Count(); numMat++)
        {
            moyClasseGen.Add(Moyenne(numMat));
        }
        Moy = Math.Round(moyClasseGen.Average(), 2);
        return Moy;
        //return 7;
    }
}

class Eleve
{
    public string nom;
    public string prenom;
    public decimal Moy;
    public int nbNote = 5;
    public int nbMat = 4;

    //Liste des notes
    public List<float> notes = new List<float>();
    public void ajouterNote(Note valeur)
    {
        notes.Add(valeur.note);
    }

    //Moyenne élève par matière
    public decimal Moyenne(int numMatiere)
    {
        List<float> moyEleve = new List<float>();
        for (int note = nbNote * numMatiere; note < nbNote * numMatiere + nbNote; note++)
        {
            moyEleve.Add(notes[note]);
        }
        Moy = Math.Round((decimal)moyEleve.Average(), 2);
        return Moy;
    }

    //Moyenne élève générale
    public decimal Moyenne()
    {
        List<decimal> moyEleveGen = new List<decimal>();
        for (int matiere = 0; matiere < nbMat; matiere++)
        {
            moyEleveGen.Add(Moyenne(matiere));
        }
        Moy = Math.Round(moyEleveGen.Average(), 2);
        return Moy;
    }
}