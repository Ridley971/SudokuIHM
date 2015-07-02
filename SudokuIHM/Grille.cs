using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SudokuIHM
{
  public class Grille
    {
        string _nom = "";
        string _date = "";
        string _symboles = "";
        public int Taille { get; set; }
        CaseSud[,] _tab = null;

        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
            }
        }

        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string Symboles
        {
            get
            {
                return _symboles;
            }
        }

        public CaseSud[,] Tab
        {
            get{return _tab;}

            set { _tab = value; }
        }

        public Grille() { }        

        public Grille(string nom, string date, string symboles)
        {
            _nom = nom;
            _date = date;
            _symboles = symboles;
            Taille = symboles.Length;
            _tab = new CaseSud[Taille, Taille];
        }

        public void addCaseSud(CaseSud caseS)
        {
            _tab[caseS.X, caseS.Y] = caseS;

        }

        public string afficherDétails()
        {
            string détails = "//--------------------------- \r\n" + _nom + " \r\n" + _date + " \r\n" + _symboles;
            return détails;
        }

        public string afficherGrille()
        {
            string strGrille = "";
            foreach (CaseSud item in _tab)
            {
                if (item.Valeur == '\0')
                    strGrille += ".";
                else
                    strGrille += item.Valeur;

                if (item.Y==_symboles.Length-1)
                {
                    strGrille +=  "\r\n";
                }
               
            }
            return strGrille;
        }

    }
}
