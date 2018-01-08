using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DUMS.Data.DataProviders.XMLDataProvider.Objects
{
    public class XMLData
    {
        #region Fields

        private string _xmlPath;
        private XDocument _xmlDocument;

        #endregion

        #region Properties
        
        public string XmlPath
        {
            get
            {
                return _xmlPath; 
            }
            set
            {
                _xmlPath = value;
            }
        }

        public XDocument XmlDocument
        {
            get
            {
                return _xmlDocument;
            }
            set
            {
                _xmlDocument = value;
            }
        }

        #endregion

        #region Constructor

        public XMLData()
        {

        }

        #endregion
    }
}
