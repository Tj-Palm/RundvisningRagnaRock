using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    public class Instrument : UDS
    {

        private string _type;

        private string _kunstner;

        public Instrument(string name, Category category, Location location, string desctiption, string pictureDirectory, string soundFileDirectory) : base(name, category, location, desctiption, pictureDirectory, soundFileDirectory)
        {

        }

        private string _description;

        public override string  Description
        {
            get { return $"Dette instrument er en {Type}. Det bliver brugt af {Kunstner}"; }   
        }


        public string Kunstner
        {
            get { return _kunstner; }
            set { _kunstner = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
