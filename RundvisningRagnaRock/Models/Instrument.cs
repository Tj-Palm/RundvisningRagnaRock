using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    public class Instrument : UDS
    {
        public Instrument(string name, Category category, string location, string desctiption, string pictureDirectory, string soundFileDirectory) : base(name, category, location, desctiption, pictureDirectory, soundFileDirectory)
        {

        }

        private string _kunstner;

        public string Kunstner
        {
            get { return _kunstner; }
            set { _kunstner = value; }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }




    }
}
