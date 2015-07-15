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
        public bool verbeux { get; set; }
        public string mesages
        {
            get;       set;
        }
      
       
        public SudokuManager() 
        {
            NomApplicattion = "Sudo Manager C#";
            ListeGrilles = new ObservableCollection<Grille>();
            verbeux = false;
            mesages ="";
        }

        #region Résolution
        private void RésoudreLigne(Grille grille, int numLigne)
            {             
               
                    List<char> caracterePresent = new List<char>();
                    goto DébutLigne;

                DébutLigne:
                    //Si tous les caractères de la grille ont été trouvés dans la ligne on passe à la ligne suivante 
                    if (caracterePresent.Count == grille.Taille)
                    {
                        Console.WriteLine("Tous les caractères ont étés trouvés pour la ligne {0}", numLigne);
                        return;
                    }

                    for (int j = 0; j < grille.Taille; j++)
                    {
                        if (grille.Tab[numLigne, j].NbreHypos == 1 && !caracterePresent.Contains(grille.Tab[numLigne, j].Valeur))
                        {
                            caracterePresent.Add(grille.Tab[numLigne, j].Valeur);
                            goto DébutLigne;
                        }
                        else if (caracterePresent.Count > 0 && grille.Tab[numLigne, j].NbreHypos > 1)
                        {
                            foreach (char carc in caracterePresent)
                            {
                                if (grille.Tab[numLigne, j].supprimerHypothese(carc))
                                {
                                    caracterePresent.Add(grille.Tab[numLigne, j].Valeur);
                                    goto DébutLigne;
                                }
                            }
                        }
                    }

                    Console.WriteLine("Nombre de caractères trouvés pour la ligne {0} est : {1} \n", numLigne, caracterePresent.Count);
                
            }

            private void RésoudreColonne(Grille grille,int  numColonne)
            {
                    List<char> caracterePresent = new List<char>();
                    goto DébutColonne;

                DébutColonne:
                    //Si tous les caractères de la grille ont été trouvés dans la colonne on passe à la colonne suivante 
                    if (caracterePresent.Count == grille.Taille)
                    {
                        Console.WriteLine("Tous les caractères ont étés trouvés pour la colonne {0}", numColonne);
                        return;
                    }

                    for (int i = 0; i < grille.Taille; i++)
                    {
                        //Ajoute le caractère de la ligne
                        if (grille.Tab[i, numColonne].NbreHypos == 1 && !caracterePresent.Contains(grille.Tab[i, numColonne].Valeur))
                        {
                            caracterePresent.Add(grille.Tab[i, numColonne].Valeur);
                            RésoudreLigne(grille, i);
                            goto DébutColonne;
                        }
                        else if (caracterePresent.Count > 0 && grille.Tab[i, numColonne].NbreHypos > 1)
                        {
                            foreach (char carc in caracterePresent)
                            {

                                if (grille.Tab[i, numColonne].supprimerHypothese(carc))
                                {
                                    caracterePresent.Add(grille.Tab[i, numColonne].Valeur);
                                    RésoudreLigne(grille, i);
                                    goto DébutColonne;
                                }
                            }
                        }
                    }

                    Console.WriteLine("Nombre de caractères trouvés pour la colonne {0} est : {1}\n", numColonne, caracterePresent.Count);
                
            }

            private bool RésoudreRégions(Grille grille)
            {
                bool régionValider = true;//Permet de savoir si toutes les régions ont étés remplies

                Console.WriteLine("\n---------------------------REGIONS--------------------------------------");

                int tailleRegion = (int)Math.Sqrt(grille.Taille);//case 9*9 =3
                int indexFinL = tailleRegion;
                int indexDébutL = 0;
                int indexDébutC = indexDébutL;
                int indexFinC = tailleRegion;
                List<char> caracterePresent = new List<char>();

                do
                {

                    goto DébutRégion;


                DébutRégion:

                    //Si tous les caractères de la grille n'ont pas étés trouvés dans la région 

                    do
                    {
                        if (caracterePresent.Count == grille.Taille)
                        {
                            régionValider = true;
                            Console.WriteLine("Tous les caractères ont étés trouvés  pour la région [{0};{1}] à [{2};{3}]",
                                indexDébutL, indexDébutC, indexFinL - 1, indexFinC - 1);
                        }
                        else
                        {
                            régionValider = false;
                            for (int i = indexDébutL; i < indexFinL; i++)
                            {
                                for (int j = indexDébutC; j < indexFinC; j++)
                                {
                                    if (grille.Tab[i, j].NbreHypos == 0 && !caracterePresent.Contains(grille.Tab[i, j].Valeur))
                                    {
                                        caracterePresent.Add(grille.Tab[i, j].Valeur);
                                        RésoudreColonne(grille, j);
                                        goto DébutRégion;
                                    }
                                    else if (caracterePresent.Count > 0 && grille.Tab[i, j].NbreHypos > 0)
                                    {
                                        foreach (char carc in caracterePresent)
                                        {
                                            if (grille.Tab[i, j].supprimerHypothese(carc))
                                            {
                                                caracterePresent.Add(grille.Tab[i, j].Valeur);
                                                RésoudreColonne(grille, j);
                                                goto DébutRégion;
                                            }
                                        }
                                    }
                                }
                            }

                            Console.WriteLine("Nombre de caractères trouvés pour la région [{0};{1}] à [{2};{3}] est : {4}\n",
                                   indexDébutL, indexDébutC, indexFinL - 1, indexFinC - 1, caracterePresent.Count);
                        }


                        indexDébutC += tailleRegion;
                        indexFinC += tailleRegion;

                        caracterePresent.Clear();
                    } while (indexFinC <= grille.Taille);


                    indexDébutC = 0;
                    indexFinC = tailleRegion;
                    indexDébutL += tailleRegion;
                    indexFinL += tailleRegion;

                } while (indexFinL <= grille.Taille);

                return régionValider;
            }


            public void RésolutionNormale(Grille g)
            {

                Stopwatch sw = new Stopwatch();
                sw.Start(); // début de la mesure

                RésoudreRégions(g);
                Console.WriteLine(  g.afficherGrille());
                    foreach (CaseSud caseSud in g.Tab)
                    {
                        if (caseSud.NbreHypos != 0)
                        {
                            break;
                        }
                    }
                
                sw.Stop(); // Fin de la mesure

                Console.WriteLine("\n Ce sudoku a été résolu en {0} millisecondes \n", sw.ElapsedMilliseconds); // Affichage de la mesure
                créerFichierRéso();
 
            }

       private bool sudBacktracking(Grille g)
            {

                return true;
            }

        #endregion


        #region Validation

        //Fonction de vérification de chaque Lignes du Sudoku passé en paramètre [Valable pour tout les Sudokus 2D]
        private  bool VérifLignes(Grille g)
        {
            for (int i = 0; i < g.Taille; i++)
            {
                Dictionary<char, int> CléCompteur = new Dictionary<char, int>();

                foreach (char symbole in g.Symboles)
                {
                    CléCompteur.Add(symbole,0);
                }

                for (int j = 0; j < g.Taille; j++)
                {
                    char s=g.Tab[i,j].Valeur;

                    if (CléCompteur.ContainsKey(s))
                    {
                        if (CléCompteur[s] == 0)
                        {
                            CléCompteur[s]++;
                        }
                        else
                        {
                            Console.WriteLine("\n  =>Ce sudoku N'EST PAS VALIDE!!!! ERREUR Á LA LIGNE {0}", i + 1);
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n  =>Ce sudoku N'EST PAS VALIDE!!!! [{0}] NE FAIT PAS PARTIT DE LA CLÉ", s);
                        return false;
                    }
                }
                CléCompteur.Clear();
            }
            return true;
        }

        //Fonction de vérification de chaque Colonnes du Sudoku passé en paramètre [Valable pour tout les Sudokus 2D]
        private bool VérifColonnes(Grille g)
        {

            for (int j = 0; j < g.Taille; j++)
            {
                Dictionary<char, int> CléCompteur = new Dictionary<char, int>();
                foreach (char symbole in g.Symboles)
                {
                    CléCompteur.Add(symbole, 0);
                }

                for (int i = 0; i < g.Taille; i++)
                {
                    char s = g.Tab[i, j].Valeur;
                    if (CléCompteur.ContainsKey(s))
                    {
                        if (CléCompteur[s] == 0)
                        {
                            CléCompteur[s]++;
                        }
                        else
                        {
                            Console.WriteLine("\n  =>Ce sudoku N'EST PAS VALIDE!!!! ERREUR Á LA COLONNE {0}", j + 1);
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n  =>Ce sudoku N'EST PAS VALIDE!!!! [{0}] NE FAIT PAS PARTIT DE LA CLÉ", s);
                        return false;
                    }
                }
                CléCompteur.Clear();
            }
            return true;
        }

        //Fonction de vérification de chaque Régions du Sudoku passé en paramètre [Valable uniquement pour Sudoku 9X9 ]
        private bool VérifRégions(Grille g)
        {
            int débuti = 0;
            do
            {
                int tailleRegion = (int)Math.Sqrt(g.Symboles.Length);
                int débutj = 0;
                int finI = débuti + tailleRegion;

                do
                {
                    Dictionary<char, int> CléCompteur = new Dictionary<char, int>();
                    foreach (char symbole in g.Symboles)
                    {
                        CléCompteur.Add(symbole, 0);
                    }

                    int finJ = débutj + tailleRegion;
                    for (int i = débuti; i < finI; i++)
                    {
                        for (int j = débutj; j < finJ; j++)
                        {
                            char num = g.Tab[i,j].Valeur;
                            if (CléCompteur.ContainsKey(num))
                            {
                                if (CléCompteur[num] == 0)
                                {
                                    CléCompteur[num]++;
                                }
                                else
                                {
                                    Console.WriteLine("\n =>Ce sudoku N'EST PAS VALIDE!!!!");
                                    return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n =>Ce sudoku N'EST PAS VALIDE!!!! [{0}] NE FAIT PAS PARTIT DE LA CLÉ", num);
                                return false;
                            }
                        }
                    }
                    débutj += tailleRegion;
                    CléCompteur.Clear();
                } while (débutj <= g.Taille);
                débuti += tailleRegion;
            } while (débuti <= g.Taille);

            return true;
        }
        
       public bool sudValidation(Grille g)
        {
            foreach (CaseSud c in g.Tab)
            {
                if (c.Valeur == '\0')
                {
                    Console.WriteLine("toutes les cases du sud " + g.Nom + " ne sont pas remplies");
                    return false;
                }
            }


            if (!VérifLignes(g) && !VérifColonnes(g) && !VérifRégions(g))
            {
                Console.WriteLine("Sudo " + g.Nom + " invalide");
                return false;
            }

            Console.WriteLine("Sudo "+g.Nom+" est valide");
            return true;
        }
        #endregion

        #region Gestion deFichier
            public void ChargerFichier(string pathFichier, bool verbeuxActif) 
            {
                verbeux = verbeuxActif;
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

                        mesages = unSudoku.afficherDétails();
                        Console.WriteLine(mesages);

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

            public void créerFichierRéso()
            {
                StreamWriter soluce = null;
                if (!File.Exists("Soluctions.sud"))
                {
                    soluce = new StreamWriter("Soluction"+grilleSelect.Nom+".sud");
                    soluce.WriteLine(grilleSelect.afficherDétails());
                    soluce.WriteLine(grilleSelect.afficherGrille());
                }
                else
                {
                    soluce = new StreamWriter("Soluction" + grilleSelect.Nom + ".sud", true);
                    soluce.WriteLine(grilleSelect.afficherDétails());
                    soluce.WriteLine(grilleSelect.afficherGrille());
                }
                mesages="Fichier créé";
            }
        #endregion

        public void clearMessages()
        {
            mesages = "";
        }

    }
}
