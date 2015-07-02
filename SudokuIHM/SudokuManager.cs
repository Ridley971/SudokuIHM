using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuIHM
{
   public class SudokuManager
    {
        //Grille grille = new Grille();
        //public SudokuManager(Grille gril)
        //{
        //    grille = gril;
        //}

       public string NomApplicattion { get; set; }
        public ObservableCollection<Grille> ListeGrilles {get;set;}
        public Grille grilleSelect { get;set;}

        public SudokuManager() 
        {
            NomApplicattion = "Sudo Manager C#";
            ListeGrilles = new ObservableCollection<Grille>();
        }
      
        //private void RésoudreLignes()
        //{

        //    Console.WriteLine("\n---------------------------LIGNES--------------------------------------");
        //    for (int numLigne = 0; numLigne < grille.Symboles.Length; numLigne++)
        //    {
        //        List<char> caracterePresent = new List<char>();
        //        goto DébutLigne;

        //    DébutLigne:
        //        //Si tous les caractères de la grille ont été trouvés dans la ligne on passe à la ligne suivante 
        //        if (caracterePresent.Count == grille.Symboles.Length)
        //        {
        //            Console.WriteLine("Tous les caractères ont étés trouvés pour la ligne {0}", numLigne);
        //            continue;
        //        }

        //        for (int j = 0; j < grille.Symboles.Length; j++)
        //        {
        //            if (grille.Tab[numLigne, j].NbreHypos == 1 && !caracterePresent.Contains(grille.Tab[numLigne, j].Valeur))
        //            {
        //                caracterePresent.Add(grille.Tab[numLigne, j].Valeur);
        //                goto DébutLigne;
        //            }
        //            else if (caracterePresent.Count > 0 && grille.Tab[numLigne, j].NbreHypos > 1)
        //            {
        //                foreach (char carc in caracterePresent)
        //                {
        //                    if (grille.Tab[numLigne, j].supprimerHypothese(carc))
        //                    {
        //                        caracterePresent.Add(grille.Tab[numLigne, j].Valeur);
        //                        goto DébutLigne;
        //                    }
        //                }
        //            }
        //        }

        //        Console.WriteLine("Nombre de caractères trouvés pour la ligne {0} est : {1} \n", numLigne, caracterePresent.Count);
        //    }
        //}

        //private void RésoudreColonnes()
        //{
        //    Console.WriteLine("\n---------------------------COLONNES--------------------------------------");
        //    for (int numColonne = 0; numColonne < grille.Symboles.Length; numColonne++)
        //    {
        //        List<char> caracterePresent = new List<char>();
        //        goto DébutColonne;

        //    DébutColonne:
        //        //Si tous les caractères de la grille ont été trouvés dans la colonne on passe à la colonne suivante 
        //        if (caracterePresent.Count == grille.Symboles.Length)
        //        {
        //            Console.WriteLine("Tous les caractères ont étés trouvés pour la colonne {0}", numColonne);
        //            continue;
        //        }

        //        for (int i = 0; i < grille.Symboles.Length; i++)
        //        {

        //            if (grille.Tab[i, numColonne].NbreHypos == 1 && !caracterePresent.Contains(grille.Tab[i, numColonne].Valeur))
        //            {
        //                caracterePresent.Add(grille.Tab[i, numColonne].Valeur);
        //                goto DébutColonne;
        //            }
        //            else if (caracterePresent.Count > 0 && grille.Tab[i, numColonne].NbreHypos > 1)
        //            {
        //                foreach (char carc in caracterePresent)
        //                {

        //                    if (grille.Tab[i, numColonne].supprimerHypothese(carc))
        //                    {
        //                        caracterePresent.Add(grille.Tab[i, numColonne].Valeur);
        //                        goto DébutColonne;
        //                    }
        //                }
        //            }
        //        }

        //        Console.WriteLine("Nombre de caractères trouvés pour la colonne {0} est : {1}\n", numColonne, caracterePresent.Count);
        //    }
        //}

        //private bool RésoudreRégions()
        //{
        //    bool régionValider = true;//Permet de savoir si toutes les régions ont étés remplies

        //    Console.WriteLine("\n---------------------------REGIONS--------------------------------------");

        //    int tailleRegion = (int)Math.Sqrt(grille.Symboles.Length);//case 9*9 =3
        //    int indexFinL = tailleRegion;
        //    int indexDébutL = 0;
        //    int indexDébutC = indexDébutL;
        //    int indexFinC = tailleRegion;
        //    List<char> caracterePresent = new List<char>();

        //    do
        //    {

        //        goto DébutRégion;


        //    DébutRégion:

        //        //Si tous les caractères de la grille n'ont pas étés trouvés dans la région 

        //        do
        //        {
        //            if (caracterePresent.Count == grille.Symboles.Length)
        //            {
        //                régionValider = true;
        //                Console.WriteLine("Tous les caractères ont étés trouvés  pour la région [{0};{1}] à [{2};{3}]",
        //                    indexDébutL, indexDébutC, indexFinL - 1, indexFinC - 1);
        //            }
        //            else
        //            {
        //                régionValider = false;
        //                for (int i = indexDébutL; i < indexFinL; i++)
        //                {
        //                    for (int j = indexDébutC; j < indexFinC; j++)
        //                    {
        //                        if (grille.Tab[i, j].NbreHypos == 1 && !caracterePresent.Contains(grille.Tab[i, j].Valeur))
        //                        {
        //                            caracterePresent.Add(grille.Tab[i, j].Valeur);
        //                            goto DébutRégion;
        //                        }
        //                        else if (caracterePresent.Count > 0 && grille.Tab[i, j].NbreHypos > 1)
        //                        {
        //                            foreach (char carc in caracterePresent)
        //                            {
        //                                if (grille.Tab[i, j].supprimerHypothese(carc))
        //                                {
        //                                    caracterePresent.Add(grille.Tab[i, j].Valeur);
        //                                    goto DébutRégion;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //                Console.WriteLine("Nombre de caractères trouvés pour la région [{0};{1}] à [{2};{3}] est : {4}\n",
        //                       indexDébutL, indexDébutC, indexFinL - 1, indexFinC - 1, caracterePresent.Count);
        //            }


        //            indexDébutC += tailleRegion;
        //            indexFinC += tailleRegion;

        //            caracterePresent.Clear();
        //        } while (indexFinC <= grille.Symboles.Length);


        //        indexDébutC = 0;
        //        indexFinC = tailleRegion;
        //        indexDébutL += tailleRegion;
        //        indexFinL += tailleRegion;

        //    } while (indexFinL <= grille.Symboles.Length);

        //    return régionValider;
        //}

        //public void RésoudreSudo()
        //{
        //    Stopwatch sw = new Stopwatch();
        //    bool rempli = true;
        //    sw.Start(); // début de la mesure
        //    do
        //    {
        //        RésoudreLignes();
        //        RésoudreColonnes();
        //        RésoudreRégions();
        //        foreach (CaseSud item in grille.Tab)
        //        {
        //            if (item.Valeur == '\0')
        //            {
        //                rempli = false;
        //                break;
        //            }
        //            rempli = true;
        //        }

        //    } while (!rempli);
        //    sw.Stop(); // Fin de la mesure

        //    Console.WriteLine("\n Ce sudoku a été résolu en {0} millisecondes \n", sw.ElapsedMilliseconds); // Affichage de la mesure
        //    créerFichierRéso();
        //}

        public void ChargerFichier(string pathFichier) 
        {
            try
            {
                StreamReader lecteur = new StreamReader(pathFichier);

                while (lecteur.Peek() > -1)
                {
                    Grille unSudoku = null;


                    Console.WriteLine(lecteur.ReadLine());//---------------------------------------
                    string nomSud = lecteur.ReadLine();//Nom du sudoku
                    string dateSud = lecteur.ReadLine();//Date du Sudoku
                    string strClé = lecteur.ReadLine();//Récupération de la clé du Sudoku
                    int taille = strClé.Length;//Détermine les dimensions du Sudoku

                    unSudoku = new Grille(nomSud, dateSud, strClé);

                    Console.WriteLine(unSudoku.afficherDétails());

                    for (int i = 0; i < taille; i++)
                    {
                        int j = 0;
                        foreach (char valeur in lecteur.ReadLine())
                        {
                            CaseSud newCase = new CaseSud(i, j++);

                            if (valeur == '.')
                            {
                                newCase.addHypotheses(strClé);
                            }
                            else
                                newCase.Valeur = valeur;

                            unSudoku.addCaseSud(newCase);
                        }
                    }

                    this.ListeGrilles.Add(unSudoku);
                    
                }
                Console.Read();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public void créerFichierRéso()
        //{
        //    StreamWriter soluce = null;
        //    if (!File.Exists("Soluctions.sud"))
        //    {
        //        soluce=new StreamWriter("Soluctions.sud");
        //        soluce.WriteLine(grille.afficherDétails());
        //        soluce.WriteLine(grille.afficherGrille());
        //    }
        //    else 
        //    {
        //        soluce = new StreamWriter("Soluctions.sud",true);
        //        soluce.WriteLine(grille.afficherDétails());
        //        soluce.WriteLine(grille.afficherGrille());
        //    }
        //}
    }
}
