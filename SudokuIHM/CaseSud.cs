using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SudokuIHM
{
    public class CaseSud
    {
        int _x;
        int _y;
        char _valeur = '\0';
        int _nbre_hypotheses = 0;
        char[] _hypotheses = null;

        #region Getters/SEtters
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public char Valeur
        {
            get
            {
                return _valeur;
            }
            set
            {
                _nbre_hypotheses = 1;
                _valeur = value;
            }
        }

        public int NbreHypos
        {
            get
            {
                return _nbre_hypotheses;
            }
            set
            {
                _nbre_hypotheses = value;
            }
        }

        public char[] Hypotheses
        {
            get
            {
                return _hypotheses;
            }
            set
            {
                _hypotheses = value;
            }
        }

        #endregion

        #region Constructeurs
        public CaseSud(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public CaseSud(char val)
        {
            _nbre_hypotheses = 1;
            _valeur = val;
        }

        public CaseSud(char[] hypots)
        {
            _nbre_hypotheses = hypots.Length;
            _hypotheses = new char[_nbre_hypotheses];
            Array.Copy(hypots, _hypotheses, _nbre_hypotheses);
        }

        public CaseSud(string hypots)
        {
            _nbre_hypotheses = hypots.Length;
            _hypotheses = new char[_nbre_hypotheses];

            _hypotheses = hypots.ToCharArray();
        }

        #endregion

        public void addHypotheses(string hypots)
        {
            _hypotheses = hypots.ToCharArray();
            _nbre_hypotheses = _hypotheses.Length;
        }

        public bool supprimerHypothese(char hypotese)
        {
            if (_nbre_hypotheses > 1)
            {
                if (Array.IndexOf(_hypotheses, hypotese) > -1)
                {

                    _hypotheses = _hypotheses.Where(val => val != hypotese).ToArray();//On supprime cet élément des hypotèses
                    _nbre_hypotheses = _hypotheses.Length;

                    Console.WriteLine("-------On supprime l'hypotèse [" + hypotese + "] de la case [{0},{1}]", this.X, this.Y);
                    if (_nbre_hypotheses == 1)
                    {
                        _valeur = _hypotheses[0];

                        Console.WriteLine("\n ++++++++++++++La case [{0},{1}] prend la valeur {2}++++++++++++++++++++++++\n", this.X, this.Y, this.Valeur);
                        return true;
                    }


                }
            }
            return false;
        }



    }
}
